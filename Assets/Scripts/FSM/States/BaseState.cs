using UnityEngine;

public class BaseState : State
{
    public override void EnterState()
    {
        //Debug.Log("Enter in: [" + this + "]");
    }

    public override void UpdateState()
    {
        //Debug.Log("Update:[" + this + "]");
    }

    public override void ExitState()
    {
        //Debug.Log("Exit in: [" + this + "]");
    }

    public BaseState(AIBrain ai, StateMachine stateMachine) : base(ai, stateMachine)
    {
        
    }

}