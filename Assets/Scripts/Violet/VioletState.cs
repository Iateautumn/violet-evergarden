using System;
using UnityEngine;

public class VioletState
{
    
    protected VioletStateMachine stateMachine;
    protected Violet violet;
    private string animBoolName;
    protected Rigidbody2D rb;
    
    protected float stateTimer;
    protected float xInput;
    protected bool triggerCalled;
    public VioletState(VioletStateMachine _stateMachine, Violet _violet, string _animBoolName)
    {
        this.stateMachine = _stateMachine;
        this.violet = _violet;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {

        violet.anim.SetBool(animBoolName, true);
        rb = violet.rb;
        this.triggerCalled = false;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        CheckInput();
        violet.anim.SetFloat("YVelocity", rb.linearVelocity.y);
        CheckFireball();
    }

    public virtual void Exit()
    {
        violet.anim.SetBool(animBoolName, false);
    }
    
    private void CheckInput() 
    {
        xInput = Input.GetAxisRaw("Horizontal");
        
    }

    public virtual void CheckFireball()
    {
        if (Input.GetKeyDown(KeyCode.K) && SkillManager.instance.fireballSkill.CanUseSkill() && violet.violetStats.GetCurrentHealth() > 0)
        {
            SkillManager.instance.fireballSkill.UseSkill();
            stateMachine.ChangeState(PlayerManager.instance.violet.fireballState);
        }
    }
    public virtual void AnimFinishTrigger()
    {
        triggerCalled = true;
    }
}
