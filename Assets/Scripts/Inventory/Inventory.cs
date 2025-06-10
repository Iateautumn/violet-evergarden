using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<InventoryItem> inventoryItems;
    public Dictionary<ItemData, InventoryItem> inventoryDic;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        inventoryItems = new List<InventoryItem>();
        inventoryDic = new Dictionary<ItemData, InventoryItem>();
    }

    public void AddItem(ItemData item)
    {
        if (inventoryDic.TryGetValue(item, out InventoryItem inventoryItem))
        {
            inventoryItem.AddStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(item, 0);
            inventoryItems.Add(newItem);
            inventoryDic.Add(item, newItem);
        }
    }

    public void RemoveItem(ItemData item)
    {
        if (inventoryDic.TryGetValue(item, out InventoryItem inventoryItem))
        {
            if (inventoryItem.stackSize <= 1)
            {
                inventoryItems.Remove(inventoryItem);
                inventoryDic.Remove(item);
            }
            else
            {
                inventoryItem.RemoveStack();
            }
        }
    }
}
