using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform inventoryPanel;
    private InventorySlot[] inventorySlots;
    private InventoryManager inventoryManager; // Sort of caching

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = SceneManager.Instance.inventoryManager;
        inventoryManager.onItemChangedCallback += UpdateUI;
        inventorySlots = inventoryPanel.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < inventoryManager.items.Count)
            {
                inventorySlots[i].AddItemToSlot(inventoryManager.items[i]);
            }
            else
            {
                inventorySlots[i].ClearSlot();
            }
        }
    }
}
