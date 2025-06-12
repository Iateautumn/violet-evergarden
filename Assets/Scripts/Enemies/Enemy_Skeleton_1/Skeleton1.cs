using UnityEngine;

public class Skeleton1 : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    #region States
    
    public Skeleton1IdleState idleState { get;private set; }
    public Skeleton1MoveState moveState { get;private set; }
    public Skeleton1BattleState battleState { get;private set; }
    public Skeleton1AttackState attackState { get; private set; }
    public Skeleton1DeadState deadState { get; private set; }
    #endregion

    [Header("Attack Settings")] 
    public float attackLength;

    public float attackWidth;
    


    public override void Awake()
    {
        base.Awake();
        moveSpeed = 5f;
        idleTime = 1f;
        facingDirection = -1;
        facingRight = false;
        
        idleState = new Skeleton1IdleState(this, stateMachine, "Idle", this);
        moveState = new Skeleton1MoveState(this, stateMachine, "Move", this);
        battleState = new Skeleton1BattleState(this, stateMachine, "Move", this);
        attackState = new Skeleton1AttackState(this, stateMachine, "Attack", this);
        deadState = new Skeleton1DeadState(this,stateMachine, "Dead", this);
    }
//to help determine the distance of sth like attack
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackCheck.position, new Vector3(attackLength,attackWidth));
    }
    
    public override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(deadState);
    }
}
