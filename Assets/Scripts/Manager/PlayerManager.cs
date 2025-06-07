using UnityEngine;

public class PlayerManager : MonoBehaviour
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
}
