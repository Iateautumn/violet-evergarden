using UnityEngine;

public class EWizardPrepareState : EWizardState
{
    public EWizardPrepareState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EWizard _eWizard) : base(_enemy, _stateMachine, _animBoolName, _eWizard)
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
            if (eWizard.transform.position.x - violet.transform.position.x < eWizard.attackCheckRadius &&
                eWizard.facingDirection == -1)
            {
                stateMachine.ChangeState(eWizard.hackState);
                return;
            }else if (violet.transform.position.x - eWizard.transform.position.x < eWizard.attackCheckRadius &&
                      eWizard.facingDirection == 1)
            {
                stateMachine.ChangeState(eWizard.hackState);
                return;
            }else if (violet.transform.position.x - eWizard.transform.position.x > eWizard.attackCheckRadius &&
                      eWizard.facingDirection == 1)
            {
                if (Random.Range(0, 2) == 0)
                {
                    stateMachine.ChangeState(eWizard.hackState);
                }
                else{
                    stateMachine.ChangeState(eWizard.fireballState);
                }
                return;
            }else if (eWizard.transform.position.x - violet.transform.position.x > eWizard.attackCheckRadius &&
                      eWizard.facingDirection == -1)
            {
                if (Random.Range(0, 2) == 0)
                {
                    stateMachine.ChangeState(eWizard.hackState);
                }
                else{
                    stateMachine.ChangeState(eWizard.fireballState);
                }
                return;
            }
            else
            {
                stateMachine.ChangeState(eWizard.hackState);
                return;
            }
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}
