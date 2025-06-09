using UnityEngine;

public class VIoletRecoverState : VioletState
{
    public VIoletRecoverState(VioletStateMachine _stateMachine, Violet _violet, string _animBoolName) : base(_stateMachine, _violet, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        violet.SetVelocity(0, 0);
    }

    public override void Update()
    {
        if (Input.GetKeyUp(KeyCode.U))
        {
            stateMachine.ChangeState(violet.idleState);
        }

        if (triggerCalled)
        {
            stateMachine.ChangeState(violet.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
