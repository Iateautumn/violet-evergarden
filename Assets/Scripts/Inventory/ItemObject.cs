using System;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 velocity;
    

    private void SetupVisual()
    {
        if (itemData == null)
            return;
        GetComponent<SpriteRenderer>().sprite = itemData.icon;
        gameObject.name = "Item object - " + itemData.name;
    }
    private void Update()
    {
        
    }

    public void SetupItem(ItemData itemData, Vector2 velocity)
    {
        this.itemData = itemData;
        this.velocity = velocity;
        rb.linearVelocity = velocity;
        SetupVisual();
    }
    
    public void PickUp()
    {
        Inventory.instance.AddItem(itemData);
        Destroy(gameObject);
    }
}
