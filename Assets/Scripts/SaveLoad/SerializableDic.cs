using System.Collections.Generic;
using UnityEngine;

// there is something can't serialized easily, I have to write it manually.
[System.Serializable]
public class SerializableDic<TKey,Tvalue> : Dictionary<TKey,Tvalue>,  ISerializationCallbackReceiver
{
    [SerializeField] private List<TKey> keys = new List<TKey>();
    [SerializeField] private List<Tvalue> values = new List<Tvalue>();
    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();
        foreach (KeyValuePair<TKey, Tvalue> pair in this)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        this.Clear();
        if (keys.Count != values.Count)
        {
            Debug.Log("Dic keys and values are not equal");
        }
        for (int i = 0; i < keys.Count; i++)
        {
            this.Add(keys[i], values[i]);
        }
    }
    
}
