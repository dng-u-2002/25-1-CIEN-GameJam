using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject
{
    protected override void Awake()
    {
        base.Awake();
        CanInteraction = true;
    }
    public bool IsOpen;
    protected override void OnPlayerEntered(Transform playerObject)
    {
    }

    protected override void OnPlayerExited(Transform playerObject)
    {
    }
    [SerializeField] Transform DoorObject;
    [SerializeField] float InteractionDelayTime = 0.5f;
    [SerializeField] float ClosedAngle;
    [SerializeField] float OpenAngle;
    bool CanInteraction;

    IEnumerator _StartInteractionDelay()
    {
        yield return new WaitForSeconds(InteractionDelayTime);
        CanInteraction = true;
    }

    protected override void OnPlayerStay(Transform playerObject)
    {
        if(CanInteraction == false)
            return;
        if (Input.GetKey(KeyCode.F))
        {
            IsOpen = !IsOpen;
            if (IsOpen)
            {
                DoorObject.localRotation = Quaternion.Euler(0, OpenAngle, 0);
            }
            else
            {
                DoorObject.localRotation = Quaternion.Euler(0, ClosedAngle, 0);
            }
            CanInteraction = false;
            StartCoroutine(_StartInteractionDelay());
        }
    }
}
