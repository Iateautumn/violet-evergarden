using UnityEngine;
using UnityEngine.SceneManagement;
// the last scene, named by the name of character
public class VioletEvergarden : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SpawnManager.instance.isFirstLoad = true;
        SceneManager.LoadScene("MainMenu"); 
    }
}


