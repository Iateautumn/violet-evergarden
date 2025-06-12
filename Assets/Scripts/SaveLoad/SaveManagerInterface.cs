using UnityEngine;

public interface SaveManagerInterface
{
    void LoadData(GameData data);
    void SaveData(ref GameData data);
}
