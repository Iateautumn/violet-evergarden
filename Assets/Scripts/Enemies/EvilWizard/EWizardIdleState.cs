using UnityEngine;

public class EWizardIdleState : EWizardState
{
    public EWizardIdleState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EWizard _eWizard) : base(_enemy, _stateMachine, _animBoolName, _eWizard)
    {
    }

    public override void Enter()
    {
        base.Enter();
        this.stateTimer = eWizard.idleTime;
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer <= 0)
        {
            stateMachine.ChangeState(eWizard.moveState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
