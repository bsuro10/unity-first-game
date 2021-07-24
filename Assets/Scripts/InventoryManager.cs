using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public delegate void onItemChanged();
    public onItemChanged onItemChangedCallback;

    public int space = 9;
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Inventory is full");
                return false;
            }

            items.Add(item);

            if(onItemChangedCallback != null)
            {
                onItemChangedCallback();
            }
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback();
        }
    }
}
