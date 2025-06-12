using UnityEngine;
// the most complex system of the game
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
    public VioletFireballState fireballState { get;private set; }
    
    public VioletRecoverState recoverState { get;private set; }
    public VioletDeadState deadState { get;private set; }
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
    [SerializeField] private float minJumpHeight = 1.5f; 
    [SerializeField] private float maxJumpHeight = 3f;     
    [SerializeField] public float jumpTimeThreshold = 0.5f; 
    public bool isJumpRelease = true;
    public float jumpTimer;
    public float floatingSpeed { get; private set; } = 13f;
    public float longJumpSpeed { get; private set; } = 17f;
    public float fallDownSpeed { get; private set; } = 11f;
    private float longJumpRate;
    public float jumpStartTime;  
    private bool isPressingJumping;      
    private bool jumpKeyHeld;   
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
    
    public VioletStats violetStats { get; private set; }
    
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
        fireballState = new VioletFireballState(stateMachine, this, "Fireball");
        recoverState = new VioletRecoverState(stateMachine, this, "Recover");
        deadState = new VioletDeadState(stateMachine, this, "Dead");
        violetStats = GetComponent<VioletStats>();
        
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

        longJumpRate = (float)0.025;
        facingRight = true;
        
    
    }

    // Update is called once per frame
    protected override void Update()
    {
        stateMachine.currentState.Update();
        DashCheck();
        AttackCheck();

    }
    
    
    private void HandleJumpHeight()
    {
        if (isPressingJumping)
        {
    
            if (jumpKeyHeld && Time.time - jumpStartTime < jumpTimeThreshold)
            {
     
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y + longJumpSpeed * longJumpRate);
            }

            else if (!jumpKeyHeld || Time.time - jumpStartTime >= jumpTimeThreshold)
            {
                isPressingJumping = false;
            }
        }
    }


    private void JumpCheck()
    {

        if (isGrounded && rb.linearVelocity.y <= 0)
        {
            isPressingJumping = false;
        }
    }

    private void CheckInput() 
    {
        xInput = Input.GetAxisRaw("Horizontal");


        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyHeld = true;
            Jump();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpKeyHeld = false;
        }


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
        
        if (Input.GetKey(KeyCode.F) && SkillManager.instance.dashSkill.CanUseSkill() && violetStats.GetCurrentHealth() > 0)
        {
            SkillManager.instance.dashSkill.UseSkill();
            stateMachine.ChangeState(dashState);
            // dashTimer = dashCoolDownTime;
        }
    }


    private void Jump()
    {
        if (isGrounded)
        {

            jumpStartTime = Time.time;
            isPressingJumping = true;

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y + longJumpSpeed * longJumpRate);
        }
    }


// set the velocity and control the facing direction
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


    public void AnimEndTrigger() => stateMachine.currentState.AnimFinishTrigger();
    

    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(deadState);
        
    }
}
