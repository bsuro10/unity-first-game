using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable
{
    public Item item;
    public override void Interact()
    {
        Collect();
    }

    protected virtual void Collect()
    {
        bool wasCollected = SceneManager.Instance.inventoryManager.Add(item);
        if (wasCollected)
        {
            Debug.Log("Collecting " + item.name);
            Destroy(gameObject);
        }
    }
}
