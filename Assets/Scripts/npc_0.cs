using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_0 : Interactable
{
    public override void Interact()
    {
        Debug.Log("Interacting: " + transform.name);
        DisableInteract();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
