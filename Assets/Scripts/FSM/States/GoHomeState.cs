using UnityEngine;

public class GoHomeState : State
{
    private Home _home;

    private Vector3 _targetPos;
    
    public GoHomeState(AIBrain ai, StateMachine stateMachine) : base(ai, stateMachine) {}

    public override void EnterState()
    {
        //Ищем объект "Дом"
        
        _home = GameObject.FindObjectOfType<Home>();
        if (_home != null)
        {
            _targetPos = _home.transform.position;
        }
        else
        {
            stateMachine.SwitchState(ai.Base); 
        }
       
        
       // Debug.Log("Enter in: [" + this + "]");
    }

    public override void UpdateState()
    {
        var AIPos = ai.gameObject.transform.position;
        
        if (Vector3.Distance(AIPos, _targetPos) > 0.2)
        {
            ai.transform.position = Vector3.MoveTowards(AIPos, _targetPos, Time.deltaTime * ai.speed);
        }
        else
        {
            ai.itemsCount = 0;
            stateMachine.SwitchState(ai.FindFood);
        }


       // Debug.Log("Update:[" + this + "]");
    }

    public override void ExitState()
    {
       // Debug.Log("Exit in: [" + this + "]");
    }
}