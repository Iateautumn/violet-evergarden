using UnityEngine;

public class EWizardJumpAttackState : EWizardState
{
    public EWizardJumpAttackState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EWizard _eWizard) : base(_enemy, _stateMachine, _animBoolName, _eWizard)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        eWizard.SetVelocity(0,- eWizard.moveSpeed * 2);
        if (eWizard.isGroundDetected())
        {
            // eWizard.anim.SetBool("isGrounded", true);
            stateMachine.ChangeState(eWizard.jumpAttackEndState);
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
