using UnityEngine;

public class EWizardTeleportState : EWizardState
{
    public EWizardTeleportState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EWizard _eWizard) : base(_enemy, _stateMachine, _animBoolName, _eWizard)
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
            if (Random.Range(0, 2) == 0)
            {
                stateMachine.ChangeState(eWizard.hackState);
            }
            else
            {
                stateMachine.ChangeState(eWizard.fireballState);
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
