using UnityEngine;

public class EWizardStats : EnemyStats
{
    protected override void Start()
    {
        base.Start();
    }

    public override void DoDamage(CharStats targetStats, float direction)
    {
        base.DoDamage(targetStats, direction);
    }

    public override void TakeDamage(int damageNum, float direction)
    {
        base.TakeDamage(damageNum, direction);
    }

    protected override void Die()
    {
        base.Die();
    }
}
