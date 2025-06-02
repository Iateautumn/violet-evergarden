using System;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemy;

    protected bool triggerCalled;
    private string animBoolName;

    protected float stateTimer;
    
    public EnemyState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
        this.enemy = _enemy;
    }

    public void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
    }

    public virtual void Exit()
    {
        // triggerCalled = false;
    }
}
