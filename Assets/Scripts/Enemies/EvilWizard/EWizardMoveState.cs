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
        IsFlipNeed();
        if (eWizard.charStats.GetCurrentHealth() < eWizard.charStats.maxHealth.GetValue() / 2f)
        {
            stateMachine.ChangeState(eWizard.halfHealthState);
            return;
        }

        if (violet.transform.position.x < eWizard.transform.position.x)
        {
            eWizard.SetVelocity(- eWizard.moveSpeed, 0);
        }
        else
        {
            eWizard.SetVelocity(eWizard.moveSpeed, 0);
        }


        if (violet.transform.position.x > eWizard.transform.position.x - eWizard.attackCheckRadius && eWizard.facingDirection == -1)
        {
            stateMachine.ChangeState(eWizard.prepareState);
            return;
        }else if (eWizard.transform.position.x + eWizard.attackCheckRadius > violet.transform.position.x && eWizard.facingDirection == 1)
        {
            stateMachine.ChangeState(eWizard.prepareState);
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
