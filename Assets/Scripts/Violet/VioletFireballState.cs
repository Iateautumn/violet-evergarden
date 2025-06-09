using UnityEngine;

public class VioletFireballState : VioletState
{
    public VioletFireballState(VioletStateMachine _stateMachine, Violet _violet, string _animBoolName) : base(_stateMachine, _violet, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Update()
    {
        base.Update();
        violet.SetVelocity(0,0);
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
