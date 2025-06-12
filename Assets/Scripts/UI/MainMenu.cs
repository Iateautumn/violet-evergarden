using System;
using UnityEngine;
using UnityEngine.SceneManagement;
// Main menu
public class MainMenu : MonoBehaviour
{
    public static string mainMenuSceneName = "MainMenu";
    public static string startSceneName = "ThePrimordium";
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject settingsPanel;

    private void Start()
    {
        if (!SaveManager.instance.HaveSavedData())
        {
            continueButton.SetActive(false);
        }
        BGMManager.instance.PlayBGM("torch");
        settingsPanel.SetActive(false);
    }

    public void ContinueGame()
    {
        Debug.Log("ContinueGame");
        BGMManager.instance.PlayBGM("ThePrimordium");

        SceneManager.LoadScene(SpawnManager.instance.sceneID);
    }

    public void NewGame()
    {
        SaveManager.instance.DeleteSavedData();
        SpawnManager.instance.spawnID = startSceneName;
        SpawnManager.instance.sceneID = startSceneName;
        SpawnManager.instance.loadedItems.Clear();
        BGMManager.instance.PlayBGM("ThePrimordium");
        SceneManager.LoadScene(startSceneName);
    }

    public void ToggleSettings()
    {
        bool isActive = settingsPanel.activeSelf;
        settingsPanel.SetActive(!isActive);
    }
    
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
    
    
}
