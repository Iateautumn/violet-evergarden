using UnityEngine;

public class VioletWallSlideState : VioletState
{
    public VioletWallSlideState(VioletStateMachine _stateMachine, Violet _violet, string _animBoolName) : base(_stateMachine, _violet, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(violet.wallJumpState);
            return;
        }
        
        if (xInput != 0 && violet.facingDirection != xInput)
        {
            stateMachine.ChangeState(violet.idleState);
        }
        
        rb.linearVelocity = new Vector2(0, violet.wallSlideSpeed);

        if (violet.isGroundDetected())
        {
            stateMachine.ChangeState(violet.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
