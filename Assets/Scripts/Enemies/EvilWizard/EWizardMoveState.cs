using UnityEngine;

public class EWizardMoveState : EWizardState
{
    public EWizardMoveState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EWizard _eWizard) : base(_enemy, _stateMachine, _animBoolName, _eWizard)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (eWizard.health < eWizard.maxHealth / 2f)
        {
            stateMachine.ChangeState(eWizard.halfHealthState);
            return;
        }

        if (violet.transform.position.x < eWizard.transform.position.x)
        {
            eWizard.SetVelocity(- eWizard.moveSpeed, 0);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
