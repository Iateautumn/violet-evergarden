using System;
using UnityEngine;

public class EnemyStats : CharStats
{
    private Enemy enemy;
    private ItemDrop myDropSys;
    protected override void Start()
    {
        base.Start();
        myDropSys = GetComponent<ItemDrop>();

    }

    protected void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    public override void TakeDamage(int damageNum, float direction)
    {
        base.TakeDamage(damageNum, direction);
        if(! isDead)
            enemy.Damage(direction);
    }

    protected override void Die()
    {
        base.Die();
        enemy.Die();
        myDropSys.GenerateDrops();
    }
}
