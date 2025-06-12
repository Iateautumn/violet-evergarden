using System.Collections.Generic;
// using UnityEditor;
using UnityEngine;

// Used throughout the entire game to store key information for scene transitions and part of the player's state.
public class SpawnManager : MonoBehaviour, SaveManagerInterface
{
    public static SpawnManager instance;

    public string spawnID;
    public int mana;
    public int health;
    public string sceneID;

    public bool isFirstLoad = true;

    public List<InventoryItem> loadedItems;

    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject); 
            return;
        }


        instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    public void LoadData(GameData data)
    {
        spawnID = data.spawnID;
        sceneID = data.sceneID;
        loadedItems = new List<InventoryItem>();
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
    }

    public void SaveData(ref GameData data)
    {
        data.spawnID = instance.spawnID;
        data.sceneID = instance.sceneID;
        
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