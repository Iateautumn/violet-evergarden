using UnityEngine;

public class VioletWallJumpState : VioletState
{
    public VioletWallJumpState(VioletStateMachine _stateMachine, Violet _violet, string _animBoolName) : base(_stateMachine, _violet, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = 0.3f;
        violet.SetVelocity(0.6f * violet.longJumpSpeed * - violet.facingDirection, 0.8f * violet.longJumpSpeed);
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
        {
            stateMachine.ChangeState(violet.airState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
