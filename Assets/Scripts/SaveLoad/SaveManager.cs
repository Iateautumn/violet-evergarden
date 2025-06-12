using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
// Used throughout the entire game to save data when the player exits.
public class SaveManager : MonoBehaviour
{
    [SerializeField] private string fileName = "saveData.json";
    public GameData gameData;
    public static SaveManager instance;
    private List<SaveManagerInterface> saveManagers;
    private FileDataHandler dataHandler;
    public void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject); 
    }

    private void Start()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        saveManagers = FindAllSaveManagers();
        LoadGame();
    }
    public void NewGame()
    {
        gameData = new GameData();
    }

    public void LoadGame()
    {
        gameData = dataHandler.Load();
        if (this.gameData == null)
        {
            NewGame();
        }

        foreach (SaveManagerInterface saveManager in FindAllSaveManagers())
        {
            saveManager.LoadData(gameData);
        }

    }

    public void SaveGame()
    {
        foreach (SaveManagerInterface saveManager in FindAllSaveManagers())
        {
            saveManager.SaveData(ref gameData);
        }
        dataHandler.Save(gameData);
        Debug.Log("SaveGame");
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<SaveManagerInterface> FindAllSaveManagers()
    {
        IEnumerable<SaveManagerInterface> saveManagers = FindObjectsOfType<MonoBehaviour>().OfType<SaveManagerInterface>();
        return new List<SaveManagerInterface>(saveManagers);
    }

    public void DeleteSavedData()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        dataHandler.Delete();
    }

    public bool HaveSavedData()
    {
        string fullPath = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(fullPath))
        {
            return true;
        }
        return false;
    }
}
