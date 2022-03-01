using UnityEngine;

public class FindFoodState : State

{
    private Item[] _items;
    private int _index;
    private Vector3 _targetPos;

    public FindFoodState(AIBrain ai, StateMachine stateMachine) : base(ai, stateMachine)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Enter in: [" + this + "]");
        //Ищем объекты на сцене с типом Item и добавляем их в массив
        _items = Object.FindObjectsOfType<Item>();
        _index = 0;
        if (_items.Length == 0)
        {
            stateMachine.SwitchState(ai.GoHome);
        }
    }


    public override void UpdateState()
    {
        if (_index != _items.Length)
        {
            _targetPos = _items[_index].transform.position;

            if (ai.inventory.Capacity > ai.inventory.Count)
            {
                if (Vector3.Distance(ai.transform.position, _targetPos) > 0.2)
                {
                    ai.transform.position = Vector3.MoveTowards
                        (ai.transform.position, _targetPos, Time.deltaTime * ai.speed);
                }

                else
                {
                    ai.inventory.Add(new Item());
                    Object.Destroy(_items[_index].gameObject);
                    _index++;
                }
            }

            else
            {
                _index = 0;
                stateMachine.SwitchState(ai.GoHome);
            }
        }
        else
        {
            stateMachine.SwitchState(ai.GoHome);
        }


        //  Debug.Log("Update:[" + this + "]");
    }


    public override void ExitState()
    {
        //Debug.Log("Exit in: [" + this + "]");
    }
}