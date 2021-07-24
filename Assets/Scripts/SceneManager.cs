using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Declare any public variables that you want to be able 
    // to access throughout your scene
    public Player player;
    public DialogueManager dialogueManager;
    public InventoryManager inventoryManager;

    public static SceneManager Instance { get; private set; } // static singleton
    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
        // Cache references to all desired variables
        player = FindObjectOfType<Player>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        inventoryManager = FindObjectOfType<InventoryManager>();
    }
}
