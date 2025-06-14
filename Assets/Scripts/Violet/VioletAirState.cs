using UnityEngine;

public class VioletAirState : VioletState
{
    public VioletAirState(VioletStateMachine _stateMachine, Violet _violet, string _animBoolName) : base(_stateMachine, _violet, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
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
        // if (xInput != 0)
        // {
        violet.SetVelocity(xInput * violet.moveSpeed, - violet.fallDownSpeed);
        // }
        if (violet.isGroundDetected())
        {
            violet.stateMachine.ChangeState(violet.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
