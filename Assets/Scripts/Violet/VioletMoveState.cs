using UnityEngine;

public class VioletMoveState : VioletGroundedState
{
    [SerializeField] private float horizonSpeed;
    public VioletMoveState(VioletStateMachine _stateMachine, Violet _violet, string _animBoolName) : base(_stateMachine, _violet, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        // Debug.Log(xInput);
        violet.SetVelocity(xInput * violet.moveSpeed, violet.rb.linearVelocity.y);
    
        if (xInput == 0)
        {
            stateMachine.ChangeState(violet.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
