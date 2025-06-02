using UnityEngine;

public class VioletStateMachine
{
    public VioletState currentState { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Initialize(VioletState _newState)
    {
        currentState = _newState;
        currentState.Enter();
    }

    public void ChangeState(VioletState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
