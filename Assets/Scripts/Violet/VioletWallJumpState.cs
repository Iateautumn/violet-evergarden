using UnityEngine;

public class VioletWallJumpState : VioletState
{
    private bool isWallJump;
    public VioletWallJumpState(VioletStateMachine _stateMachine, Violet _violet, string _animBoolName) : base(_stateMachine, _violet, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        violet.jumpTimer = violet.wallJumpTotalTimeThreshold;
        violet.isJumpRelease = false;
        violet.SetVelocity(0.6f * violet.longJumpSpeed * - violet.facingDirection, 0.8f * violet.longJumpSpeed);
    }

    public override void Update()
    {
        base.Update();
        
        if (violet.jumpTimer < 0)
        {
            stateMachine.ChangeState(violet.airState);
        }
        longJump();
        if (violet.isGroundDetected())
        {
            stateMachine.ChangeState(violet.idleState);
        }
    }
    // the longer space pressed, the higher player jump
    public void longJump()
    {
        if (!violet.isJumpRelease && Input.GetKeyUp(KeyCode.Space))
        {
  
            violet.isJumpRelease = true;
            stateMachine.ChangeState(violet.airState);
            return;
        }
        else if (!violet.isJumpRelease && violet.jumpTimer < violet.wallJumpTotalTimeThreshold - violet.wallJump1TimeThreshold)
        {

            stateMachine.ChangeState(violet.wallJump2State);
            return;
        }
        else if (!violet.isJumpRelease)
        {

            violet.SetVelocity(0.6f * violet.longJumpSpeed * violet.facingDirection, 0.8f * violet.longJumpSpeed);
        }
        
        violet.jumpTimer -= Time.deltaTime;
    }
    public override void Exit()
    {
        base.Exit();
    }
}
