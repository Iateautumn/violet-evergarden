using UnityEngine;
// when user come from other scene, this class will specify corresponding spawnpoint
public class Spawner : MonoBehaviour
{
    public GameObject playerPrefab;

    private void Start()
    {
        // get the spawnpoint
        Debug.Log("later" + SpawnManager.instance.loadedItems);
        string spawnID = SpawnManager.instance.spawnID;
        SpawnPoint[] allSpawns = FindObjectsOfType<SpawnPoint>();
        if (!SpawnManager.instance.isFirstLoad)
        {
            PlayerManager.instance.violet.violetStats.SetMana(SpawnManager.instance.mana);
            PlayerManager.instance.violet.violetStats.SetHealth(SpawnManager.instance.health);
        }

        foreach (var sp in allSpawns)
        {

            if (sp.spawnID.Equals(spawnID) )
            {

                if (PlayerManager.instance.violet != null)
                {
                    PlayerManager.instance.violet.transform.position = sp.transform.position;
                    PlayerManager.instance.violet.transform.rotation = sp.transform.rotation;
                }
                break;
            }
        }
    }
}