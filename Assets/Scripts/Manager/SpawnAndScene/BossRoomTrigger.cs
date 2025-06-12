using UnityEngine;

using Unity.Cinemachine;
// Trigger for boss
public class BossRoomTrigger : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform bossSpawnPoint;
    public GameObject[] doorsToClose;
    public CinemachineCamera bossCamera;  
    public CinemachineCamera playerCamera ;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered || collision.GetComponent<Violet>() == null)
        {
            return;
        }

        triggered = true;


        Instantiate(bossPrefab, bossSpawnPoint.position, bossSpawnPoint.rotation);

        // close the Boss Room door
        foreach (GameObject door in doorsToClose)
        {
            door.SetActive(true);
        }
        
        BGMManager.instance.PlayBGMWithFadeIn("EWizard");

        // Pin the camera
        if (bossCamera != null && playerCamera != null)
        {
            bossCamera.Priority = 20;
            playerCamera.Priority = 10;
        }
        
        gameObject.SetActive(false);
            
    }
}