using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Urinal : InteractableObject
{
    [SerializeField] AudioSource ASource;
    [SerializeField] float InteractionDelayTime = 0.5f;

    bool CanInteraction;

    IEnumerator _StartInteractionDelay()
    {
        yield return new WaitForSeconds(InteractionDelayTime);
        CanInteraction = true;
    }
    protected override void Awake()
    {
        base.Awake();
        ASource = GetComponent<AudioSource>();
    }

    protected override void OnPlayerEntered(Transform playerObject)
    {
    }

    protected override void OnPlayerExited(Transform playerObject)
    {
    }

    protected override void OnPlayerStay(Transform playerObject)
    {
        if (CanInteraction == false)
            return;
        if (Input.GetKey(KeyCode.F))
        {
            ASource.Stop();
            if (ASource.isPlaying == false)
            {
                ASource.Play();
            }
            CanInteraction = false;
            StartCoroutine(_StartInteractionDelay());
        }
    }
}
