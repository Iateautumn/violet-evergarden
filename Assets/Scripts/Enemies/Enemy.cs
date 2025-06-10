using UnityEngine;

public class Enemy : Mobs
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public EnemyStateMachine stateMachine;
    

    
    [SerializeField] protected LayerMask playerLayer;
    
    #region Battle
    [Header("Collision Check")]
    [SerializeField] Transform attackDistanceCheck;
    [SerializeField] public float detectRange = 50;
    [SerializeField] public float attackDistance = 10f;
    public float attackCoolDown = 0.1f;
    [HideInInspector] public float lastAttackTime;
    public float battleSpeedRate { get; private set; } = 1.2f;
    public float battleTime { get; private set; } = 3f;
    
    #endregion
    
    #region Move
    [Header("Move Settings")] 
    [SerializeField] public float idleTime;
    [SerializeField] public float moveSpeed;
    
    #endregion

    public override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }
    

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * facingDirection, transform.position.y));
    }
    public virtual void AnimEndTrigger() => stateMachine.currentState.AnimFinishTrigger();
    public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, detectRange, playerLayer);
}
