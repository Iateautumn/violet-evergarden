using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarInBK : HealthBar
{
    [SerializeField] private TextMeshProUGUI itemText => GetComponentInChildren<TextMeshProUGUI>();

    public override void SetMaxHealth(int maxHealth)
    {
        base.SetMaxHealth(maxHealth);
        itemText.text = "Health: " + maxHealth.ToString() + '/' + maxHealth.ToString();
    }
    public override void SetHealthBar(int health)
    {
        base.SetHealthBar(health);
        itemText.text = "Health: " + slider.value.ToString() + '/' + slider.maxValue.ToString();
    }
}
