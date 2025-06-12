using System.Collections.Generic;
using UnityEngine;
// used to initialize the drops of mobs
public class ItemDrop : MonoBehaviour
{
    [SerializeField] private GameObject dropPrefab;
    [SerializeField] private ItemData item;
    private List<ItemData> dropList = new List<ItemData>();
    [SerializeField] private ItemData[] possibleDrops;
    private int maxDrop = 3;

    public void GenerateDrops()
    {
        for (int i = 0; i < possibleDrops.Length; i++)
        {
            for (int j = 0; j < Random.Range(0, maxDrop + 1); j++)
            {
                dropList.Add(possibleDrops[i]);
            }
        }

        for (int i = 0; i < dropList.Count; i++)
        {
            DropItem(dropList[i]);
        }
    }
    public void DropItem(ItemData dropItem)
    {
        GameObject newDrop = Instantiate(dropPrefab, transform.position, Quaternion.identity);
        Vector2 randomVector = new Vector2(Random.Range(-10f, 10f), Random.Range(5f, 10f));
        newDrop.GetComponent<ItemObject>().SetupItem(dropItem, randomVector);
    }
}
