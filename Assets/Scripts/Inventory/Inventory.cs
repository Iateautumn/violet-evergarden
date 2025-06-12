using System;
using System.Collections.Generic;
// using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour, SaveManagerInterface
{
    public static Inventory instance;
    public List<InventoryItem> inventoryItems;
    public Dictionary<ItemData, InventoryItem> inventoryDic;
    

    [Header("Inventory Settings")]
    [SerializeField] private Transform inventorySlotParent;

    private ItemSlot[] itemSlot;
    [Header("Database")] 
    public string[] assetNames;
    
    public List<InventoryItem> loadedItems;
    
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
        if (SpawnManager.instance.loadedItems != null)
        {
            loadedItems = SpawnManager.instance.loadedItems;
            Debug.Log("loadedItems" + loadedItems.Count);
        }
        itemSlot = inventorySlotParent.GetComponentsInChildren<ItemSlot>();
        AddStartingItems();
    }

    private void AddStartingItems()
    {
        if (loadedItems.Count > 0)
        {
            foreach (InventoryItem item in loadedItems)
            {
                for (int i = 0; i < item.stackSize; i++)
                {
                    AddItem(item.data);
                }
            }

            return;
        }
    }
    private void UpdateSlot()
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            itemSlot[i].UpdateSlot(inventoryItems[i]);
        }
    }
    public void AddItem(ItemData item)
    {
        if (inventoryDic.TryGetValue(item, out InventoryItem inventoryItem))
        {
            inventoryItem.AddStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(item, 1);
            inventoryItems.Add(newItem);
            inventoryDic.Add(item, newItem);
        }
        UpdateSlot();
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
        UpdateSlot();
    }

    public void LoadData(GameData data)
    {
        foreach (KeyValuePair<string, int> pair in data.inventory)
        {
            foreach (var item in GetItemDataBase())
            {
                if (item != null && item.itemID == pair.Key)
                {
                    InventoryItem newItem = new InventoryItem(item, 1);
                    newItem.stackSize = pair.Value;
                    loadedItems.Add(newItem);
                }
            }
        }
        Debug.Log(loadedItems);
    }

    public void SaveData(ref GameData data)
    {
        data.inventory.Clear();
        foreach (KeyValuePair<ItemData, InventoryItem> pair in inventoryDic)
        {
            data.inventory.Add(pair.Key.itemID, pair.Value.stackSize);
        }
    }

    private List<ItemData> GetItemDataBase()
    {
        // List<ItemData> itemDatabase = new List<ItemData>();
        // string[] assetNames = AssetDatabase.FindAssets("",new[]{"Assets/Entity/Item"});
        // foreach (string assetName in assetNames)
        // {
        //     var SOpath = AssetDatabase.GUIDToAssetPath(assetName);
        //     var itemData = AssetDatabase.LoadAssetAtPath<ItemData>(SOpath);
        //     itemDatabase.Add(itemData);
        // }
        // return itemDatabase;
        ItemData[] items = Resources.LoadAll<ItemData>("Items");
        return new List<ItemData>(items);
    }
}
