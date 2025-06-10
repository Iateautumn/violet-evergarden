using UnityEngine;

public class Skeleton1GroundState : Skeleton1State
{
    public Skeleton1GroundState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, Skeleton1 _skeleton1) : base(_enemy, _stateMachine, _animBoolName, _skeleton1)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (skeleton1.IsPlayerDetected())
        {
            stateMachine.ChangeState(skeleton1.battleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
