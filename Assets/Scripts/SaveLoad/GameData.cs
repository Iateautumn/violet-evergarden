using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameData
{
    public int a;
    public SerializableDic<string, int> inventory;
    public string sceneID;
    public string spawnID;


    public GameData()
    {
        a = 0;
        inventory = new SerializableDic<string, int>();
    }
}
