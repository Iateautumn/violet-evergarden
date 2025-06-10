using UnityEngine;

public class EWizardJumpAttackEndState : EWizardState
{
    public EWizardJumpAttackEndState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EWizard _eWizard) : base(_enemy, _stateMachine, _animBoolName, _eWizard)
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
            stateMachine.ChangeState(eWizard.idleState);
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
