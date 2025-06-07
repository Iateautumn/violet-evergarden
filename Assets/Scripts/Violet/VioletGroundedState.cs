using UnityEngine;

public class VioletGroundedState : VioletState
{
    public VioletGroundedState(VioletStateMachine _stateMachine, Violet _violet, string _animBoolName) : base(_stateMachine, _violet, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (!violet.isGroundDetected())
        {
            violet.stateMachine.ChangeState(violet.airState);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (violet.attackTimer < 0)
            {
                stateMachine.ChangeState(violet.primaryAttackState);
                violet.attackTimer = violet.attackCoolDownTime;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            violet.isJumpRelease = false;
            violet.jumpTimer = violet.jumpTimeThreshold;
            violet.stateMachine.ChangeState(violet.jumpState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
