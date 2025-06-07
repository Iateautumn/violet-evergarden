using UnityEngine;

public class Skeleton1AttackState : Skeleton1State
{
    public Skeleton1AttackState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EnemySkeleton1 _skeleton1) : base(_enemy, _stateMachine, _animBoolName, _skeleton1)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        skeleton1.SetVelocity(0 ,0);
        if (triggerCalled)
        {
            stateMachine.ChangeState(skeleton1.battleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        skeleton1.lastAttackTime = Time.time;
    }
}
