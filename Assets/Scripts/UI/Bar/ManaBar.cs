using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;

    public virtual void SetMaxMana(int maxMana)
    {
        slider.maxValue = maxMana;
        slider.value = maxMana;
    }

    public virtual void SetManaBar(int mana)
    {
        slider.value = mana;
    }
}
