using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

public class Player : BaseObject
{
    [SerializeField] float Speed;
    CharacterController ThisCharacterController;

    public static Player Instance;

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
        ThisCharacterController = GetComponent<CharacterController>();
    }
    Vector3 GravityFactor;
    private void Update()
    {
        if (FindObjectOfType<CheckListUIDrawer>().IsShowing == true)
            return;

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        //Vector3 direction = (new Vector3(inputX, 0, inputY)).normalized;

        Transform cam = Camera.main.transform;
        Vector3 camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 camRight = Vector3.Scale(cam.right, new Vector3(1, 0, 1)).normalized;

        Vector3 direction = (camForward * inputY + camRight * inputX).normalized;


        bool isGrounded = ThisCharacterController.isGrounded;
        if(isGrounded == false)
        {
            GravityFactor += Physics.gravity * Time.deltaTime;
        }
        else
        {
            GravityFactor = Vector3.zero;
        }

        ThisCharacterController.Move(direction * Speed * Time.deltaTime + GravityFactor * Time.deltaTime);
    }
}
