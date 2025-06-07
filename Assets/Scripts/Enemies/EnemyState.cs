using System;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemy;

    protected bool triggerCalled;
    private string animBoolName;

    protected float stateTimer;
    
    // protected Rigidbody2D rb;
    
    public EnemyState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
        this.enemy = _enemy;
    }
    
    public virtual void Enter()
    {
        triggerCalled = false;
        enemy.anim.SetBool(animBoolName, true);
    }
    
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void Exit()
    {
        // triggerCalled = false;
        enemy.anim.SetBool(animBoolName, false);
    }
    
    public virtual void AnimFinishTrigger()
    {
        triggerCalled = true;
    }
    
    
}
