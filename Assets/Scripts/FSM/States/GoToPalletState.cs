using UnityEngine;


public class GoToPalletState : State
{
    private Pallete[] _pallets;
    private Vector3 _target;

    public GoToPalletState(AIBrain ai, StateMachine stateMachine) : base(ai, stateMachine)
    {
    }

    public override void EnterState()
    {
        _pallets = Object.FindObjectsOfType<Pallete>();
        
        for (int i = 0; i < _pallets.Length; i++)
        {
            if (_pallets[i].PalleteHasItem())
            {
                _target = _pallets[i].transform.position;
            }
        }

        if (_target == Vector3.zero)
        {
            stateMachine.SwitchState(ai.Base);
        }

        Debug.Log("Enter in: [" + this + "]");
    }

    public override void UpdateState()
    {
        var AIPos = ai.gameObject.transform.position;
        
        if (Vector3.Distance(AIPos, _target) > 0.2)
        {
            Debug.Log("Going to");
            ai.transform.position = Vector3.MoveTowards(AIPos, _target, Time.deltaTime * ai.speed);
        }
        else
        {
            stateMachine.SwitchState(ai.Base);
            Debug.Log("No pallets");
        }

      //  Debug.Log("Update:[" + this + "]");
    }

    public override void ExitState()
    {
        _pallets = null;
        // Debug.Log("Exit in: [" + this + "]");
    }
}