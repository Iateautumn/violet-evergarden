using UnityEngine;

public class Violet : Mobs
{
    public VioletIdleState idleState { get;private set; }
    
    public VioletMoveState moveState { get;private set; }
    
    public VioletStateMachine stateMachine { get;private set; }
    public VioletJumpState jumpState { get;private set; }
    public VioletAirState airState { get;private set; }
    public VioletDashState dashState { get;private set; }
    public VioletWallSlideState wallSlideState { get;private set; }
    public VioletWallJumpState wallJumpState { get;private set; }
    public VioletPrimaryAttackState primaryAttackState { get;private set; }
    public VioletAirAttackState airAttackState { get; private set; }
    public VioletWallJump2State wallJump2State { get;private set; }
    
    [SerializeField] private float horizonSpeed;


    private float xInput;
    [Header("Move Settings")]
    [SerializeField] private bool isMoving;
    [SerializeField] private float jumpSpeed;
    [SerializeField] public float wallSlideSpeed { get;private set; } = -3f;
    [SerializeField] public float moveSpeed { get; private set; } = 9f;

    [Header("dash")] 
    [SerializeField] public float dashDuration { get; private set; } = 0.20f;
    [SerializeField] public float dashSpeed { get; private set; } = 35f;


    // [SerializeField] private bool dashCoolDown;
    
    
    [Header("Long Jump Settings")]
    [SerializeField] private float minJumpHeight = 1.5f;   // 短跳最小高度
    [SerializeField] private float maxJumpHeight = 3f;     // 长跳最大高度
    [SerializeField] public float jumpTimeThreshold = 0.5f; // 长按时间阈值
    public bool isJumpRelease = true;
    public float jumpTimer;
    public float floatingSpeed { get; private set; } = 13f;
    public float longJumpSpeed { get; private set; } = 17f;
    public float fallDownSpeed { get; private set; } = 11f;
    private float longJumpRate;
    public float jumpStartTime;  // 记录跳跃开始时间
    private bool isPressingJumping;       // 标记是否正在跳跃
    private bool jumpKeyHeld;     // 标记跳跃键是否被按住
    public float wallJumpSpeed { get; private set; } = 17f;
    public float wallJumpTotalTimeThreshold { get; private set; } = 0.35f;
    public float wallJump1TimeThreshold { get; private set; } = 0.15f;

    [Header("Attack Settings")]
    [SerializeField] public float attackCoolDownTime { get; private set; } = 0.4f;
    [SerializeField] public float attackTimer = 0;
    private float comboTime = 0.3f;
    private float comboTimeWindow;
    private bool isAttacking;
    private int comboCounter;
    

    public override void Awake()
    {
        
        stateMachine = new VioletStateMachine();

        moveState = new VioletMoveState(stateMachine, this, "Move");
        
        idleState = new VioletIdleState(stateMachine, this, "Idle");
        jumpState = new VioletJumpState(stateMachine, this, "Jump");
        airState = new VioletAirState(stateMachine, this, "Jump");
        dashState = new VioletDashState(stateMachine, this, "Dash");
        wallSlideState = new VioletWallSlideState(stateMachine, this, "WallSlide");
        wallJumpState = new VioletWallJumpState(stateMachine, this, "Jump");
        primaryAttackState = new VioletPrimaryAttackState(stateMachine, this, "Attack");
        airAttackState = new VioletAirAttackState(stateMachine, this, "Attack");
        wallJump2State = new VioletWallJump2State(stateMachine, this, "WallJump2");
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {

        base.Start();
        stateMachine.Initialize(idleState);
        
        horizonSpeed = 5f;
        jumpSpeed = 7;
        longJumpSpeed = 14;
        fallDownSpeed = 11;
        jumpTimeThreshold = 0.4f;
        // facingDirection = 1;
        longJumpRate = (float)0.025;
        facingRight = true;
        
        //GroundCheckDistance = (float)1.26;
    }

    // Update is called once per frame
    protected override void Update()
    {
        stateMachine.currentState.Update();
        DashCheck();
        AttackCheck();
        // base.Update();
        // CheckInput();
        // Movement();
        // JumpCheck();
        //
        // comboTimeWindow -= Time.deltaTime;
        // HandleJumpHeight(); // 跳高控制
        // FlipController();
        // AnimatorController();
        // Debug.Log(isGrounded);
    }
    
    
    private void HandleJumpHeight()
    {
        if (isPressingJumping)
        {
            // 只有在按住跳跃键时才增加跳跃高度
            if (jumpKeyHeld && Time.time - jumpStartTime < jumpTimeThreshold)
            {
                // 持续施加跳跃力
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y + longJumpSpeed * longJumpRate);
            }
            // 当松开跳跃键或达到最大时间时结束跳跃状态
            else if (!jumpKeyHeld || Time.time - jumpStartTime >= jumpTimeThreshold)
            {
                isPressingJumping = false;
            }
        }
    }


    private void JumpCheck()
    {
        // 落地时重置跳跃状态
        if (isGrounded && rb.linearVelocity.y <= 0)
        {
            isPressingJumping = false;
        }
    }

    private void CheckInput() 
    {
        xInput = Input.GetAxisRaw("Horizontal");

        // 检测跳跃键按下
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyHeld = true;
            Jump();
        }

        // 检测跳跃键释放
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpKeyHeld = false;
        }
        // dashTime -= Time.deltaTime;
        // if (dashTime <  - dashCoolDownTime && Input.GetKeyDown(KeyCode.F))
        // {
        //     dashTime = dashDuration;
        // }

        if (Input.GetKeyDown(KeyCode.J))
        {
            StartAttackEvent();
        }

    }

    private void AttackCheck()
    {
        attackTimer -= Time.deltaTime;
    }
    private void DashCheck()
    {
        
        if (Input.GetKey(KeyCode.F) && SkillManager.instance.dashSkill.CanUseSkill())
        {
            stateMachine.ChangeState(dashState);
            // dashTimer = dashCoolDownTime;
        }
    }
    
    // private void Movement()
    // {
    //     if (dashTimer > 0)
    //     {
    //         rb.linearVelocity = new Vector2(facingDirection * dashSpeed, 0);
    //     }
    //     else
    //     {
    //         rb.linearVelocity = new Vector2(xInput * horizonSpeed, rb.linearVelocity.y);
    //     }
    // }

    private void Jump()
    {
        if (isGrounded)
        {
            // 记录跳跃开始时间
            jumpStartTime = Time.time;
            isPressingJumping = true;
            
            // 应用基础跳跃速度
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y + longJumpSpeed * longJumpRate);
        }
    }

    // private void AnimatorController()
    // {
    //     isMoving = rb.linearVelocity.x != 0;
    //     anim.SetBool("isMoving", isMoving);
    //     anim.SetBool("isGrounded", isGrounded);
    //     anim.SetBool("isDashing", dashTimer > 0);
    //     anim.SetBool("isAttacking", isAttacking);
    //     anim.SetInteger("comboCounter", comboCounter);
    // }

    public override void SetVelocity(float _XVelocity, float _YVelocity)
    {
        rb.linearVelocity = new Vector2(_XVelocity, _YVelocity);
        FlipController(_XVelocity);
    }

    private void FlipController(float _XVelocity)
    {
        if (_XVelocity > 0 && !facingRight)
        {
            Flip();
        }
        else if (_XVelocity < 0 && facingRight)
        {
            Flip();
        }
            
    }



    public void AttackOver()
    {
        isAttacking = false;

        comboCounter++;
        comboCounter = comboCounter % 1;
        
    }
    private void StartAttackEvent()
    {
        if (!isGrounded)
        {
            return;
        }
        if (comboTimeWindow < 0)
        {
            comboCounter = 0;
        }
        isAttacking = true;
        comboTimeWindow = comboTime;
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }

    // public float jumpSpeedFunc(float time)
    // {
    //     
    // }

    public void AnimEndTrigger() => stateMachine.currentState.AnimFinishTrigger();

    // public override void Damage()
    // {
    //     base.Damage();
    //     StartCoroutine("HitKnockback");
    //
    // }
    

    
}
