using System;
using UnityEngine;

public class EnemyStats : CharStats
{
    private Enemy enemy;
    protected override void Start()
    {
        base.Start();

    }

    protected void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    public override void TakeDamage(int damageNum, float direction)
    {
        base.TakeDamage(damageNum, direction);
        Debug.Log("hello");
        enemy.Damage(direction);
    }

    protected override void Die()
    {
        base.Die();
        enemy.Die();
    }
}
