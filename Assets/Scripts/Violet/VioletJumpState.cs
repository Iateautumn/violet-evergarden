using UnityEngine;

public class VioletJumpState : VioletState
{
    public VioletJumpState(VioletStateMachine _stateMachine, Violet _violet, string _animBoolName) : base(_stateMachine, _violet, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, violet.longJumpSpeed);
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.J) && violet.attackTimer < 0)
        {
            violet.stateMachine.ChangeState(violet.airAttackState);
            violet.attackTimer = violet.attackCoolDownTime;
            return;
        }
        if (violet.isWallDetected())
        {
            violet.stateMachine.ChangeState(violet.wallSlideState);
        }
        if (xInput != 0)
        {
            violet.SetVelocity(xInput * violet.moveSpeed, rb.linearVelocity.y);
        }
        if (rb.linearVelocity.y < 0)
        {
            stateMachine.ChangeState(violet.airState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
