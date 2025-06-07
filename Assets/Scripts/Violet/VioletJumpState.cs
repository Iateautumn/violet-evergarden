using UnityEngine;

public class VioletJumpState : VioletState
{

    public VioletJumpState(VioletStateMachine _stateMachine, Violet _violet, string _animBoolName) : base(_stateMachine, _violet, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // rb.linearVelocity = new Vector2(rb.linearVelocity.x, violet.longJumpSpeed);
        
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
        longJump();

        // if (violet.isWallDetected())
        // {
        //     violet.stateMachine.ChangeState(violet.wallSlideState);
        // }

        violet.SetVelocity(xInput * violet.moveSpeed, rb.linearVelocity.y);
        if (rb.linearVelocity.y <= 0)
        {
            stateMachine.ChangeState(violet.airState);
        }
    }

    public void longJump()
    {
        if (!violet.isJumpRelease)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, violet.longJumpSpeed);
        }
        if (!violet.isJumpRelease && (Input.GetKeyUp(KeyCode.Space) || violet.jumpTimer < 0))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 2);
            violet.isJumpRelease = true;
        }
        violet.jumpTimer -= Time.deltaTime;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
