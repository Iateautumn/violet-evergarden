using UnityEngine;

public class EWizardTeleportAboveState : EWizardState
{
    public EWizardTeleportAboveState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EWizard _eWizard) : base(_enemy, _stateMachine, _animBoolName, _eWizard)
    {
    }

    public override void Enter()
    {
        base.Enter();
        eWizard.isGroundDetected();
    }

    public override void Update()
    {
        base.Update();
        eWizard.SetVelocity(0,0);
        if (triggerCalled)
        {
            stateMachine.ChangeState(eWizard.jumpAttackState);
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
