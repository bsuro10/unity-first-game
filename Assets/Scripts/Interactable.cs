using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Interactable : MonoBehaviour
{
    public bool isInteractEnable { get; set; } = true;
    public abstract void Interact();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInteractEnable)
        {
            Debug.Log("Press 'E' to interact");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isInteractEnable)
        {
            Debug.Log("Exit interaction zone");
        }
    }
}
