using UnityEngine;

public class EWizardState : EnemyState
{
    protected EWizard eWizard;
    protected Violet violet => PlayerManager.instance.violet;
    public EWizardState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EWizard _eWizard) : base(_enemy, _stateMachine, _animBoolName)
    {
        this.eWizard = _eWizard;
    }

    
    public override void Enter()
    {   
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }

    protected virtual void ToIdleState()
    {
        if (triggerCalled)
        {
            stateMachine.ChangeState(eWizard.idleState);
        }
    }

    protected virtual void IsFlipNeed()
    {
        if ((violet.transform.position.x - eWizard.transform.position.x) * eWizard.facingDirection < 0)
        {
            eWizard.Flip();
        }
    }
    
}
