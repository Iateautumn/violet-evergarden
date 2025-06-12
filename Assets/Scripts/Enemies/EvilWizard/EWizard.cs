using UnityEngine;
// the boss of the game
public class EWizard : Enemy
{



    public bool isGrounded = true;
    
    #region states
    public EWizardIdleState idleState { get;private set; }
    public EWizardMoveState moveState { get;private set; }
    public EWizardHackState hackState { get;private set; }
    public EWizardJumpState jumpState { get;private set; }
    public EWizardPrepareState prepareState { get;private set; }
    public EWizardTeleportState teleportState { get;private set; }
    public EWizardHalfHealthState halfHealthState { get;private set; }
    public EWizardFireballState fireballState { get;private set; }
    public EWizardTeleportAboveState teleportAboveState { get;private set; }
    public EWizardJumpAttackState jumpAttackState { get;private set; }
    public EWizardJumpAttackEndState jumpAttackEndState{get;private set;}
    public EWizardDeadState deadState { get;private set; }
    
    #endregion

    
    [SerializeField] public float hackWidth;
    
    public override void Awake()
    {
        base.Awake();
        // idleTime = 0.5f;
        stateMachine = new EnemyStateMachine();
        idleState = new EWizardIdleState(this, stateMachine, "Idle", this);
        moveState = new EWizardMoveState(this, stateMachine, "Move", this);
        jumpState = new EWizardJumpState(this,stateMachine, "Jump", this);
        prepareState = new EWizardPrepareState(this,stateMachine, "Prepare", this);
        hackState = new EWizardHackState(this, stateMachine, "Hack", this);
        teleportState = new EWizardTeleportState(this, stateMachine, "Teleport", this);
        halfHealthState = new EWizardHalfHealthState(this,stateMachine, "Move", this);
        fireballState = new EWizardFireballState(this,stateMachine, "Fireball", this);
        teleportAboveState = new EWizardTeleportAboveState(this, stateMachine, "TeleportAbove", this);
        jumpAttackState = new EWizardJumpAttackState(this, stateMachine, "JumpAttack", this);
        jumpAttackEndState = new EWizardJumpAttackEndState(this, stateMachine, "JumpAttackEnd",this);
        deadState = new EWizardDeadState(this,stateMachine, "Dead", this);


    }

    public override void Start()
    {
        base.Start();
        // eWizardStats = GetComponent<EWizardStats>();
        stateMachine.Initialize(idleState);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackCheck.position, new Vector3(attackCheckRadius,hackWidth));
    }
    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(deadState);
    }
    public override RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(attackCheck.position, Vector2.right * facingDirection, detectRange, playerLayer);
}
