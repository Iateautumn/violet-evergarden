using UnityEngine;

public class VioletIdleState : VioletGroundedState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public VioletIdleState(VioletStateMachine _stateMachine, Violet _violet, string _animBoolName) : base(_stateMachine, _violet, _animBoolName)
    {
    }
    

    // Update is called once per frame
    public override void Enter()
    {
        base.Enter();
        violet.SetVelocity(0,0);
    }

    public override void Update()
    {
        base.Update();

        if (xInput != 0)
        {
            stateMachine.ChangeState(violet.moveState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
    
}
