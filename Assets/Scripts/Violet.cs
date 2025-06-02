using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float horizonSpeed;
    [SerializeField] private float jumpSpeed;
    private Animator ani;
    private float xInput;
    [SerializeField] private bool isMoving;
    private Rigidbody2D rb;
    private int facingDirection;
    private bool facingRight;
    [Header("Jump Info")]
    [SerializeField] private float GroundCheckDistance;
    [SerializeField] private LayerMask GroundLayer;
    private bool isGrounded;
    [Header("dash")] 
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashCoolDownTime;

    // [SerializeField] private bool dashCoolDown;
    
    
    [Header("Long Jump Settings")]
    [SerializeField] private float minJumpHeight = 1.5f;   // 短跳最小高度
    [SerializeField] private float maxJumpHeight = 3f;     // 长跳最大高度
    [SerializeField] private float jumpTimeThreshold; // 长按时间阈值
    [SerializeField] private float longJumpSpeed;
    private float longJumpRate;
    private float jumpStartTime;  // 记录跳跃开始时间
    private bool isPressingJumping;       // 标记是否正在跳跃
    private bool jumpKeyHeld;     // 标记跳跃键是否被按住

    [Header("Attack Settings")]
    private float comboTime = 0.3f;
    private float comboTimeWindow;
    private bool isAttacking;
    private int comboCounter;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
        rb = GetComponent<Rigidbody2D>();
        horizonSpeed = 5f;
        jumpSpeed = 7;
        longJumpSpeed = 14;
        jumpTimeThreshold = 0.3f;
        facingDirection = 1;
        longJumpRate = (float)0.025;
        facingRight = true;
        dashTime = 0;
        dashSpeed = 18;
        dashDuration = 0.15f;
        ani = GetComponentInChildren<Animator>();
        dashCoolDownTime = 0.2f;
        //GroundCheckDistance = (float)1.26;
    }

    // Update is called once per frame
    void Update()
    {

        CheckInput();
        Movement();
        JumpCheck();

        comboTimeWindow -= Time.deltaTime;
        HandleJumpHeight(); // 跳高控制
        FlipController();
        AnimatorController();
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
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, GroundCheckDistance, GroundLayer);
        
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
        dashTime -= Time.deltaTime;
        if (dashTime <  - dashCoolDownTime && Input.GetKeyDown(KeyCode.F))
        {
            dashTime = dashDuration;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            StartAttackEvent();
        }

    }
    
    private void Movement()
    {
        if (dashTime > 0)
        {
            rb.linearVelocity = new Vector2(facingDirection * dashSpeed, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(xInput * horizonSpeed, rb.linearVelocity.y);
        }
    }

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

    private void AnimatorController()
    {
        isMoving = rb.linearVelocity.x != 0;
        ani.SetBool("isMoving", isMoving);
        ani.SetBool("isGrounded", isGrounded);
        ani.SetBool("isDashing", dashTime > 0);
        ani.SetBool("isAttacking", isAttacking);
        ani.SetInteger("comboCounter", comboCounter);
    }

    private void Flip()
    {
        facingDirection = -1 * facingDirection;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void FlipController()
    {
        if (rb.linearVelocity.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (rb.linearVelocity.x < 0 && facingRight)
        {
            Flip();
        }
            
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - GroundCheckDistance));
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

}
