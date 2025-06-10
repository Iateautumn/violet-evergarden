using UnityEngine;

public class EWizardFireballState : EWizardState
{
    public EWizardFireballState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EWizard _eWizard) : base(_enemy, _stateMachine, _animBoolName, _eWizard)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        eWizard.SetVelocity(0,0);
        ToIdleState();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
