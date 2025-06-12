using UnityEngine;

public class VioletMoveState : VioletGroundedState
{
    [SerializeField] private float horizonSpeed;
    public VioletMoveState(VioletStateMachine _stateMachine, Violet _violet, string _animBoolName) : base(_stateMachine, _violet, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        PlayerManager.instance.violet.GetComponentInChildren<MobsSEF>().PlayLoopSound(MobsSEF.SoundType.Move);
    }

    public override void Update()
    {
        base.Update();
        // Debug.Log(xInput);
        violet.SetVelocity(xInput * violet.moveSpeed, violet.rb.linearVelocity.y);
    
        if (xInput == 0)
        {
            stateMachine.ChangeState(violet.idleState);
        }
    }

    public override void Exit()
    {
        PlayerManager.instance.violet.GetComponentInChildren<MobsSEF>().StopLoopSound();
        base.Exit();
    }
}
