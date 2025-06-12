using UnityEngine;
//character states, parent class of all stat class
public class CharStats : MonoBehaviour
{
    public Stat damage;
    public Stat maxHealth;
    public Stat maxMana;
    [SerializeField] protected int currentHealth;
    [SerializeField] protected int currentMana;
    protected bool isDead = false;
    protected virtual void Start()
    {
        currentHealth = maxHealth.GetValue();   
        currentMana = maxMana.GetValue();
    }

    public virtual void DoDamage(CharStats targetStats, float direction)
    {
        int damageTotal = this.damage.GetValue();
        targetStats.TakeDamage(damageTotal, direction);
        
    }
    // Update is called once per frame
    public virtual void TakeDamage(int damageNum, float direction)
    {
        if (!isDead)
        {
            currentHealth -= damageNum;
            if (currentHealth <= 0)
            {
                isDead = true;
                Die();
            }
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetCurrentMana()
    {
        return currentMana;
    }
    protected virtual void Die()
    {
        
    }

    public virtual void Recover(int healthNum)
    {
        currentHealth += healthNum;
        if (currentHealth > maxHealth.GetValue())
        {
            currentHealth = maxHealth.GetValue();
        }
    }

    public virtual void IncreaseMana(int manaNum)
    {
        currentMana += manaNum;
        if (currentMana >= maxMana.GetValue())
        {
            currentMana = maxMana.GetValue();
        }
        else if(currentMana < 0)
        {
            currentMana = 0;
        }

    }

    public virtual bool IsManaEnough(int manaNum)
    {
        return currentMana >= manaNum;
    }
}
