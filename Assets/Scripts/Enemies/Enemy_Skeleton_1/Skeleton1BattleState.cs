using UnityEngine;

public class Skeleton1BattleState : Skeleton1State
{
    private Transform player;
    public Skeleton1BattleState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, Skeleton1 _skeleton1) : base(_enemy, _stateMachine, _animBoolName, _skeleton1)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = skeleton1.battleTime;
        player = PlayerManager.instance.violet.transform;
    }

    public override void Update()
    {
      
        base.Update();
        if (IsFlipNeed())
        {
            skeleton1.Flip();
        }
        skeleton1.SetVelocity(skeleton1.moveSpeed * skeleton1.facingDirection * skeleton1.battleSpeedRate, skeleton1.rb.linearVelocity.y);
        if (skeleton1.IsPlayerDetected())
        {
            stateTimer = skeleton1.battleTime;
            if (skeleton1.IsPlayerDetected().distance < skeleton1.attackDistance)
            {
                if (CanAttack())
                    stateMachine.ChangeState(skeleton1.attackState);
            }
        }

        if (stateTimer < 0)
        {
            stateMachine.ChangeState(skeleton1.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    private bool IsFlipNeed()
    {
        if ((player.transform.position.x - skeleton1.rb.position.x) * skeleton1.facingDirection < 0)
        {
            return true;
        }
        return false;
    }

    private bool CanAttack()
    {
        if (Time.time >= skeleton1.attackCoolDown + skeleton1.lastAttackTime)
        {
            return true;
        }
        return false;
    }
    
}
