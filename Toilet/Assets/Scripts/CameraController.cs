using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

[RequireComponent(typeof(Camera))]
public class CameraController : BaseObject
{
    Camera ThisCamera;
    [SerializeField] float Speed;
    [SerializeField] float XRotMultiplier = 1;
    // Start is called before the first frame update
    void Start()
    {
        ThisCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<CheckListUIDrawer>().IsShowing == true)
            return;
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * Speed;
        float mouseY = -Input.GetAxis("Mouse Y") * Time.deltaTime * Speed * XRotMultiplier;

        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        //ThisTransform.localRotation = rotation * ThisTransform.localRotation;
        ThisTransform.localEulerAngles += new Vector3(mouseY, mouseX, 0);

        var euler = ThisTransform.localEulerAngles;
        euler.z = 0;
        ThisTransform.localEulerAngles = euler;
        //euler.x = (euler.x + 720) % 360.0f;
        //if (euler.x <= 320f)
        //    euler.x = 320;
        //else if (euler.x >= 40f)
        //    euler.x = 40;
        //Debug.Log(euler.x);
        euler.x = Mathf.Clamp(euler.x, -40, 40);
    }
}
