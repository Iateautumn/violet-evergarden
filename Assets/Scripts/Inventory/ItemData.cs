using System;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class ItemData : ScriptableObject
{

    public string itemName;
    public Sprite icon;
    public string itemID;
    
    public float dropChance; //can be used in the future
    private void OnValidate()
    {
#if UNITY_EDITOR
        string path = AssetDatabase.GetAssetPath(this);
        itemID = AssetDatabase.AssetPathToGUID(path);
#endif
    }
}
