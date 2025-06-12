using UnityEngine;

public class PlayerManager : MonoBehaviour, SaveManagerInterface
{
    
    public static PlayerManager instance;
    public Violet violet;

    public void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
        {
            instance = this;
        }

    }

    public void LoadData(GameData data)
    {
        Debug.Log(data.a);
    }

    public void SaveData(ref GameData data)
    {
        data.a = 1;
    }
}
