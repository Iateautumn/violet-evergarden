using UnityEngine;
using UnityEngine.UI;
using TMPro;

    public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image ItemImage;
    [SerializeField] private TextMeshProUGUI ItemText;
    public InventoryItem item;



    public void UpdateSlot(InventoryItem item)
    {
        this.item = item;
        if (item != null)
        {
            ItemImage.sprite = item.data.icon;
            if (item.stackSize > 1)
            {
                ItemText.text = item.stackSize.ToString();
            }
            else
            {
                ItemText.text = "";
            }
        }
    }

}
