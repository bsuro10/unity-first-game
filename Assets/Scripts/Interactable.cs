using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[SerializeField]
public abstract class Interactable : MonoBehaviour
{
    public bool isInteractAvailable = true;
    public abstract void Interact();

    protected void DisableInteract()
    {
        isInteractAvailable = false;
    }

    protected void EnableInteract()
    {
        isInteractAvailable = true;
    }

    public bool InteractAvailable()
    {
        return isInteractAvailable;
    }
}
