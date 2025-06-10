using UnityEngine;

public class VioletWallJump2State : VioletState
{
    public bool originDir;
    public VioletWallJump2State(VioletStateMachine _stateMachine, Violet _violet, string _animBoolName) : base(_stateMachine, _violet, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
        violet.SetVelocity(0.6f * violet.wallJumpSpeed * -violet.facingDirection, 0.8f * violet.wallJumpSpeed);
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("hello");
        if (!violet.isJumpRelease && Input.GetKeyUp(KeyCode.Space) || violet.jumpTimer < 0)
        {
            violet.isJumpRelease = true;
            stateMachine.ChangeState(violet.airState);
            return;
        }
        if (!violet.isJumpRelease)
        {
            if (Input.GetKey(KeyCode.A) && violet.facingDirection == -1)
            {
                violet.SetVelocity(0.6f * violet.wallJumpSpeed * violet.facingDirection, 0.8f * violet.wallJumpSpeed);
            }
            else if (Input.GetKey(KeyCode.D) && violet.facingDirection == 1)
            {
                violet.SetVelocity(0.6f * violet.wallJumpSpeed * violet.facingDirection, 0.8f * violet.wallJumpSpeed);

            }
            else
            {
                stateMachine.ChangeState(violet.jumpState);
                return;
            }
        }
        violet.jumpTimer -= Time.deltaTime;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
