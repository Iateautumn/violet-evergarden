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
        if (triggerCalled)
        {
            // if (rb.linearVelocity.y >= 0)
            // {
            //     stateMachine.ChangeState(violet.jumpState);
            // }
            // else
            stateMachine.ChangeState(violet.airState);
            // }
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
