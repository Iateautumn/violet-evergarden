using System;
using UnityEngine;

public class Skeleton1 : Mobs
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;
    
    [Header("Player Detection")]
    [SerializeField] private float playerCheckDistance;
    [SerializeField] private LayerMask playerLayer;

    private bool isAttacking;
    private float playerFoundSpeedFactor = 2;
    
    private RaycastHit2D isPlayerDetected;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        facingRight = false;
        // facingDirection = -1;
        Flip();
    }

    protected override void Update()
    {
        base.Update();

        if (isPlayerDetected)
        {
            if (isPlayerDetected.distance > 1)
            {
                rb.linearVelocity = new Vector2(moveSpeed * playerFoundSpeedFactor * facingDirection, rb.linearVelocity.y);
                isAttacking = false;
            }
            else
            {
                isAttacking = true;
            }
            
        }
        
        if (!isGrounded || isWallFound)
        {
            Flip();
        }
        
    }

    private void Movement()
    {
        if (!isPlayerDetected)
        {
            rb.linearVelocity = new Vector2(moveSpeed * facingDirection, rb.linearVelocity.y);            
        }
    }

    protected override void CollisionCheck()
    {
        base.CollisionCheck();
        isPlayerDetected = Physics2D.Raycast(transform.position, Vector2.right, playerCheckDistance * facingDirection, playerLayer);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + facingDirection * playerCheckDistance,transform.position.y));
    }
}
