using UnityEngine;

public class EnemySkeleton1 : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    #region States
    
    public Skeleton1IdleState idleState { get;private set; }
    public Skeleton1MoveState moveState { get;private set; }
    public Skeleton1BattleState battleState { get;private set; }
    #endregion
    


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
}
