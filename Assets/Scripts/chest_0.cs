using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest_0 : Interactable
{
    // Can make 'Openable' class to inheritance from Interactable but for now I will just put the vars here (for open and close)
    public Sprite openedChest;
    public Dialogue dialogue;
    public int rubiesAmount;
    private SpriteRenderer spriteRenderer;

    public override void Interact()
    {
        spriteRenderer.sprite = openedChest;
        SceneManager.Instance.dialogueManager.StartDialogue(dialogue);
        isInteractEnable = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        dialogue.sentences = new DialogueElement[2];
        dialogue.sentences[0] = new DialogueElement("Chest", new Color32(35, 127, 255, 255), "You found . . . ", new Color32(50, 50, 50, 255));
        dialogue.sentences[1] = new DialogueElement("Chest", new Color32(35, 127, 255, 255), rubiesAmount + " Rubies!", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
