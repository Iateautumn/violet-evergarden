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
    }

    public virtual void Exit()
    {
        violet.anim.SetBool(animBoolName, false);
    }
    
    private void CheckInput() 
    {
        xInput = Input.GetAxisRaw("Horizontal");

        // 检测跳跃键按下
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     jumpKeyHeld = true;
        //     Jump();
        // }
        //
        // // 检测跳跃键释放
        // if (Input.GetKeyUp(KeyCode.Space))
        // {
        //     jumpKeyHeld = false;
        // }
        // dashTime -= Time.deltaTime;
        // if (dashTime <  - dashCoolDownTime && Input.GetKeyDown(KeyCode.F))
        // {
        //     dashTime = dashDuration;
        // }
        //
        // if (Input.GetKeyDown(KeyCode.J))
        // {
        //     StartAttackEvent();
        // }
    }

    public virtual void AnimFinishTrigger()
    {
        triggerCalled = true;
    }
}
