using UnityEngine;

public class VioletDashState : VioletState
{
    public VioletDashState(VioletStateMachine _stateMachine, Violet _violet, string _animBoolName) : base(_stateMachine, _violet, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = violet.dashDuration;
    }

    public override void Update()
    {
        base.Update();
        violet.SetVelocity(violet.dashSpeed * violet.facingDirection, 0);
        if (stateTimer < 0)
        {
            violet.stateMachine.ChangeState(violet.idleState);
        }
    }

    public override void CheckFireball()
    {
        return;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
