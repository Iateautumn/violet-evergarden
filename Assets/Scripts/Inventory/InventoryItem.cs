using System;
using UnityEngine;
[Serializable]
public class InventoryItem
{
    public ItemData item;
    public int stackSize;

    public InventoryItem(ItemData item, int stackSize)
    {
        this.item = item;
        this.stackSize = stackSize;
    }
    public void AddStack() => stackSize++;
    public void RemoveStack() => stackSize--;

}
