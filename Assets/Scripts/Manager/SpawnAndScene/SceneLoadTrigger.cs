using UnityEngine;
using UnityEngine.SceneManagement;
// trigger of scene switch
public class SceneLoaderTrigger : MonoBehaviour
{
    public string sceneToLoad;
    public string targetSpawnID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Violet>() != null)
        {
  
            Debug.Log(SpawnManager.instance.spawnID);
            SpawnManager.instance.spawnID = targetSpawnID;
            SpawnManager.instance.isFirstLoad = false;
            SpawnManager.instance.loadedItems = Inventory.instance.inventoryItems;
            SpawnManager.instance.mana = PlayerManager.instance.violet.charStats.GetCurrentMana();
            SpawnManager.instance.health = PlayerManager.instance.violet.charStats.GetCurrentHealth();
            SpawnManager.instance.sceneID = string.Copy(sceneToLoad);
            
            SceneManager.LoadScene(sceneToLoad);
        }

    }
}