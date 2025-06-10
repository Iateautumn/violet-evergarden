using UnityEngine;

public class Skeleton1MoveState : Skeleton1GroundState
{


    public Skeleton1MoveState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, Skeleton1 _skeleton1) : base(_enemy, _stateMachine, _animBoolName, _skeleton1)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        skeleton1.SetVelocity(skeleton1.moveSpeed * skeleton1.facingDirection, skeleton1.rb.linearVelocity.y);
        if (! skeleton1.isGroundDetected() || skeleton1.isWallDetected())
        {
            skeleton1.Flip();
            stateMachine.ChangeState(skeleton1.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
