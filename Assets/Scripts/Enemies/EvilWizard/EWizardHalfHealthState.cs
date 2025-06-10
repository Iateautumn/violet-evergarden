using UnityEngine;

public class EWizardHalfHealthState : EWizardState
{
    public EWizardHalfHealthState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EWizard _eWizard) : base(_enemy, _stateMachine, _animBoolName, _eWizard)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (Random.Range(0, 3) == 1)
        {
            stateMachine.ChangeState(eWizard.teleportAboveState);
            return;
        }
        else
        {
            stateMachine.ChangeState(eWizard.teleportState);
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
