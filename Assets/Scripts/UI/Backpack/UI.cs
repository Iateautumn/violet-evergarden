using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// In game UI
public class UI : MonoBehaviour
{
    public GameObject InGameUI;
    public GameObject VioletUI;
    public GameObject SettingsUI;
    public GameObject HelpUI;
    public GameObject[] menus;
    private int currentMenu;
    private Dictionary<int, GameObject> numberToMenu;
 
    void Start()
    {
        numberToMenu = new Dictionary<int, GameObject>();
        numberToMenu.Add(0, InGameUI);
        numberToMenu.Add(1, VioletUI);
        numberToMenu.Add(2, HelpUI);
        numberToMenu.Add(3, SettingsUI);
        SwichTo(numberToMenu[currentMenu]);
        currentMenu = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMenu == 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SwichTo(numberToMenu[++ currentMenu]);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentMenu = 0;
                SwichTo(numberToMenu[currentMenu]);
            }
        }
    }

 
    public void SwichTo(GameObject menu)
    {
        Debug.Log(menu.name);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        if (menu != null)
        {
            menu.SetActive(true);
        }
    }

    public void SaveAndExit()
    {
        SaveManager.instance.SaveGame();
        BGMManager.instance.PlayBGM("torch");
        SceneManager.LoadScene(MainMenu.mainMenuSceneName);
    }
}
