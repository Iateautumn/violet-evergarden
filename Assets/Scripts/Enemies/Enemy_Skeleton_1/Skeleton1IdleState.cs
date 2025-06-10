using UnityEngine;

public class Skeleton1IdleState : Skeleton1GroundState

{
    public Skeleton1IdleState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, Skeleton1 _skeleton1) : base(_enemy, _stateMachine, _animBoolName, _skeleton1)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = skeleton1.idleTime;
        skeleton1.SetVelocity(0, 0);
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
        {
            stateMachine.ChangeState(skeleton1.moveState);
        }
        
    }

    public override void Exit()
    {
        base.Exit();
    }
}
