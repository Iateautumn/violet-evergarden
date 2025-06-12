using UnityEngine;

public class VioletAirAttackState : VioletState
{
    public VioletAirAttackState(VioletStateMachine _stateMachine, Violet _violet, string _animBoolName) : base(_stateMachine, _violet, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        longJump();
        if (triggerCalled && rb.linearVelocity.y <= 0)
        {

            stateMachine.ChangeState(violet.airState);
            return;
            // }
        }
        else if (triggerCalled && rb.linearVelocity.y > 0)
        {
            stateMachine.ChangeState(violet.jumpState);
            return;
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
