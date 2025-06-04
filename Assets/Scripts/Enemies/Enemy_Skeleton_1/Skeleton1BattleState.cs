using UnityEngine;

public class Skeleton1BattleState : Skeleton1State
{
    private Transform player;
    public Skeleton1BattleState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EnemySkeleton1 _skeleton1) : base(_enemy, _stateMachine, _animBoolName, _skeleton1)
    {
    }

    public override void Enter()
    {
        base.Enter();



    }

    public override void Update()
    {
      
        base.Update();
        skeleton1.SetVelocity(skeleton1.moveSpeed * skeleton1.facingDirection * skeleton1.battleSpeedRate, skeleton1.rb.linearVelocity.y);
        if (skeleton1.IsPlayerDetected().distance < skeleton1.attackDistance)
        {
            Debug.Log("Attack");
        }
        if (!skeleton1.IsPlayerDetected())
        {
            stateMachine.ChangeState(skeleton1.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
