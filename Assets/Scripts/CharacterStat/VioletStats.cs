using UnityEngine;

public class VioletStats : CharStats
{

    private Violet violet=>PlayerManager.instance.violet;
    public Stat fireballDamage;
    public HealthBar healthBar;
    public HealthBarInBK healthBarInBK;
    public ManaBar manaBar;
    public ManaBarInBK manaBarInBK;
    public BasicInfo basicInfo;
    
    protected override void Start()
    {
        base.Start();

        healthBar.SetMaxHealth(maxHealth.GetValue());
        manaBar.SetMaxMana(maxMana.GetValue());
        healthBarInBK.SetMaxHealth(maxHealth.GetValue());
        manaBarInBK.SetMaxMana(maxMana.GetValue());
        basicInfo.SetText(damage.GetValue(), SkillManager.instance.fireballSkill.damage);
        
        if (!SpawnManager.instance.isFirstLoad)
        {
            currentHealth = SpawnManager.instance.health;
            currentMana = SpawnManager.instance.mana;
            healthBar.SetHealthBar(currentHealth);
            manaBar.SetManaBar(currentMana);
            healthBarInBK.SetHealthBar(currentHealth);
            manaBarInBK.SetManaBar(currentMana);
        }

        
        damage.AddABuff(5);

    }

    public override void TakeDamage(int damageNum, float direction)
    {
        if (SkillManager.instance.getDamagedSkill.CanUseSkill())
        {
            SkillManager.instance.getDamagedSkill.UseSkill();
            base.TakeDamage(damageNum, direction);
            violet.Damage(direction);
            healthBar.SetHealthBar(GetCurrentHealth());
            healthBarInBK.SetHealthBar(GetCurrentHealth());
        }
    }

    public void DoFireballDamage(CharStats targetStats, float direction)
    {
        int damageTotal = fireballDamage.GetValue();
        targetStats.TakeDamage(damageTotal, direction);
    }

    protected override void Die()
    {
        base.Die();
        violet.Die();
    }

    public override void DoDamage(CharStats targetStats, float direction)
    {
        base.DoDamage(targetStats, direction);
        IncreaseMana(Random.Range(10,31));
    }

    public override void Recover(int healthNum)
    {
        base.Recover(healthNum);
        healthBar.SetHealthBar(GetCurrentHealth());
        healthBarInBK.SetHealthBar(GetCurrentHealth());
    }

    public override void IncreaseMana(int mana)
    {
        base.IncreaseMana(mana);
        manaBar.SetManaBar(GetCurrentMana());
        manaBarInBK.SetManaBar(GetCurrentMana());
    }

    public void SetMana(int mana)
    {
        currentMana = mana;
        manaBar.SetManaBar(GetCurrentMana());

    }
    
    public void SetHealth(int health)
    {
        currentHealth = health;
        SetBar();
    }

    private void SetBar()
    {
        healthBar.SetHealthBar(GetCurrentHealth());
        manaBarInBK.SetManaBar(GetCurrentMana());
        healthBarInBK.SetHealthBar(GetCurrentHealth());
        manaBar.SetManaBar(GetCurrentMana());
    }
}
