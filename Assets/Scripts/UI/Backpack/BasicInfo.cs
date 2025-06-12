using System;
using TMPro;
using UnityEngine;

public class BasicInfo : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI[] itemTexts => GetComponentsInChildren<TextMeshProUGUI>();

    // public void Awake()
    // {
    //     itemTexts = GetComponentsInChildren<TextMeshProUGUI>();
    // }

    public void SetText(int damage, int magicDamage)
    {
        itemTexts[0].text = "Attack: " + damage.ToString();
        itemTexts[1].text = "Magic Attack: " + magicDamage.ToString();
    }
}
