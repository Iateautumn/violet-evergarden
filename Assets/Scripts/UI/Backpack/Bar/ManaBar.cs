using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarInBK : ManaBar
{
    [SerializeField] private TextMeshProUGUI itemText => GetComponentInChildren<TextMeshProUGUI>();
    public override void SetMaxMana(int maxMana)
    {
        slider.maxValue = maxMana;
        slider.value = maxMana;
        itemText.text = "Health: " + maxMana.ToString() + '/' + maxMana.ToString();
    }

    public override void SetManaBar(int mana)
    {
        slider.value = mana;
        itemText.text = "Health: " + slider.value.ToString() + '/' + slider.maxValue.ToString();
    }
}
