using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public virtual void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
    public virtual void SetHealthBar(int health)
    {
        slider.value = health;
    }
}
