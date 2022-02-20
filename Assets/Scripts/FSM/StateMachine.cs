using System;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State CurrentState { get; set; }
    [SerializeField] private string currentState;

    public void SetState(State newState)
    {
        CurrentState = newState;
        CurrentState.EnterState();
    }

    public void SwitchState(State newState)
    {
        CurrentState.ExitState();
        CurrentState = newState;
        CurrentState.EnterState();
    }

    public void UpdateState()
    {
        CurrentState.UpdateState();
        ViewCurrentState();
    }

    public string GetCurrentState()
    {
       return CurrentState.ToString();
    }

    public void ViewCurrentState()
    {
        currentState = CurrentState.ToString();
    }
}