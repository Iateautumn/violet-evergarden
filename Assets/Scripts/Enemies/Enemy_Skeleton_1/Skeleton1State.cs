using UnityEngine;

public class Skeleton1State : EnemyState
{
    protected Skeleton1 skeleton1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public Skeleton1State(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, Skeleton1 _skeleton1) : base(_enemy, _stateMachine, _animBoolName)
    {
        this.skeleton1 = _skeleton1;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
