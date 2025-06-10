using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] private int baseValue;
    public List<int> buffs;

    public int GetValue()
    {
        int value = baseValue;
        foreach (var buff in buffs)
        {
            value += buff;
        }
        
        return value;
    }

    public void AddABuff(int buff)
    {
        buffs.Add(buff);
    }

    public void RemoveABuff(int buff)
    {
        buffs.RemoveAt(buff);
    }
    
}
