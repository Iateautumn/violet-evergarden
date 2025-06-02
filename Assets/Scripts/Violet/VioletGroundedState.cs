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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            violet.stateMachine.ChangeState(violet.jumpState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
