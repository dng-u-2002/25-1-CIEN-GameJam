using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public  abstract class InteractableObject : BaseObject
{
    Rigidbody ThisRigidbody;
    Collider[] ThisColliders;
    protected override void Awake()
    {
        base.Awake();

        ThisRigidbody = GetComponent<Rigidbody>();
        ThisColliders = GetComponents<Collider>();

        ThisRigidbody.isKinematic = true;

        foreach (Collider collider in ThisColliders)
        {
            collider.isTrigger = true;
        }
    }


    protected abstract void OnPlayerEntered(Transform playerObject);
    protected abstract void OnPlayerExited(Transform playerObject);
    protected abstract void OnPlayerStay(Transform playerObject);

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            OnPlayerEntered(other.transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            OnPlayerStay(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            OnPlayerExited(other.transform);
        }
    }
}
