using UnityEngine;

public class VioletStats : CharStats
{

    private Violet violet=>PlayerManager.instance.violet;
    public Stat fireballDamage;
    public HealthBar healthBar;
    public ManaBar manaBar;
    
    protected override void Start()
    {
        base.Start();
        healthBar.SetMaxHealth(maxHealth.GetValue());
        manaBar.SetMaxMana(maxMana.GetValue());
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
    }

    public override void IncreaseMana(int mana)
    {
        base.IncreaseMana(mana);
        manaBar.SetManaBar(GetCurrentMana());
    }
}
