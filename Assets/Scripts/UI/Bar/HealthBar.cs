using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        Debug.Log("hello");
        slider.value = maxHealth;
    }
    public void SetHealthBar(int health)
    {
        slider.value = health;
    }
}
