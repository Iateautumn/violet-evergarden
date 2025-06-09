using UnityEngine;

public class EWizard : Enemy
{
    [SerializeField] public float idleTime = 0.5f;
    
    
    
    #region states
    public EWizardIdleState idleState { get;private set; }
    public EWizardMoveState moveState { get;private set; }
    public EWizardHackState hackState { get;private set; }
    public EWizardJumpState jumpState { get;private set; }
    public EWizardPrepareState prepareState { get;private set; }
    public EWzardTeleportState teleportState { get;private set; }
    public EWzardHalfHealthState halfHealthState { get;private set; }
    
    #endregion

    [Header("Move Settings")]
    [SerializeField] public float moveSpeed;
    
    [Header("Combat Settings")] 
    [SerializeField] public float maxHealth;
    [SerializeField] public float health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
        idleState = new EWizardIdleState(this, stateMachine, "Idle", this);
        moveState = new EWizardMoveState(this, stateMachine, "Move", this);
        jumpState = new EWizardJumpState(this,stateMachine, "Jump", this);
        prepareState = new EWizardPrepareState(this,stateMachine, "Prepare", this);
        hackState = new EWizardHackState(this, stateMachine, "Hack", this);
        teleportState = new EWzardTeleportState(this, stateMachine, "Teleport", this);
        halfHealthState = new EWzardHalfHealthState(this,stateMachine, "HalfHealth", this);

    }
}
