using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_0 : Interactable
{
    public Dialogue dialogue;

    public override void Interact()
    {
        SceneManager.Instance.dialogueManager.StartDialogue(dialogue);
        GameObject.Find("Portal").GetComponent<BoxCollider2D>().enabled = true;
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
