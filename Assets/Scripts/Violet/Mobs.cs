using System.Collections;
using UnityEngine;
using UnityEngine.VFX;
// the parent of Player and mobs
public class Mobs : MonoBehaviour
{
    public Rigidbody2D rb; //{ get; private set; }
    public Animator anim; //{ get; private set; }
    public MobsFlash mf;
    public CharStats charStats { get;private set; }
    
    [Header("Collision Check")]
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected LayerMask groundLayer;
    
    [Header("Knockback Settings")]
    [SerializeField] protected Vector2 knockbackDirection;
    [SerializeField] protected float knockbackDuration;
    protected bool isKnocked;

    public Transform attackCheck;
    public float attackCheckRadius;
    
    protected bool isGrounded;
    protected bool isWallFound;
    
    public int facingDirection { get; protected set; } = 1;
    protected bool facingRight = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public virtual void Awake()
    {

    }
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        mf = GetComponent<MobsFlash>();
        charStats = GetComponent<CharStats>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        CollisionCheck();
    }
    
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * facingDirection, wallCheck.position.y));
    }
    
    public virtual bool isGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
    public virtual bool isWallDetected() =>Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance  * facingDirection, groundLayer);

    protected virtual void CollisionCheck()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
        isWallFound = Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance  * facingDirection, groundLayer);
    }
    
    public virtual void Flip()
    {
        facingDirection = -1 * facingDirection;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public virtual void SetVelocity(float _XVelocity, float _YVelocity)
    {
        if (isKnocked)
            return;
        rb.linearVelocity = new Vector2(_XVelocity, _YVelocity);
    }

    public virtual void Damage(float dir)
    {
        mf.StartCoroutine("HitFlash");
        StartCoroutine("HitKnockback",dir);
    }

    protected virtual IEnumerator HitKnockback(float hitDir)
    {
        isKnocked = true;
        
        rb.linearVelocity = new Vector2(knockbackDirection.x * hitDir, knockbackDirection.y);
        
        yield return new WaitForSeconds(knockbackDuration); 
        
        isKnocked = false;
        
    }

    public virtual void Die()
    {
        
    }
}
