using UnityEngine;
public class FindFoodState : State
{
    public Item[] SearchedItems;
    private int _index;
    private Vector3 _targetPos;
    public FindFoodState(AIBrain ai, StateMachine stateMachine) : base(ai, stateMachine) {}
    public override void EnterState()
    {
        Debug.Log("Enter in: [" + this + "]");

        //Ищем объекты на сцене с типом Item и добавляем их в массив
        SearchedItems = Object.FindObjectsOfType<Item>();
        _index = 0;
        if (SearchedItems.Length == 0)
        {
            stateMachine.SwitchState(ai.Base);
        }
    }

    public override void UpdateState()
    {
        Debug.Log(_targetPos = SearchedItems[_index].transform.position);
        Debug.Log(_index);
        _targetPos = SearchedItems[_index].transform.position;
        
        if (ai.inventory.Capacity > ai.inventory.Count)
        {
            Debug.Log("Goo");
            //То двигаемся к объекту
            if (Vector3.Distance(ai.transform.position, _targetPos) > 0.2)
            {
                ai.transform.position = Vector3.MoveTowards(ai.transform.position, _targetPos, Time.deltaTime * ai.speed);
            }
            //Как дойдем - удаляем его со сцены, кидаем в инвентарь и движемся к следующему
            else
            {
                ai.inventory.Add(SearchedItems[_index]);
                Object.Destroy(SearchedItems[_index].gameObject);
                _index++;
                Debug.Log("Else index" + _index);
            }
        }
        
        else
        {
            Debug.Log("else");
            _index = 0;
            stateMachine.SwitchState(ai.GoHome);
        }
        
      //  Debug.Log("Update:[" + this + "]");
    }
    


    public override void ExitState()
    {
        //Debug.Log("Exit in: [" + this + "]");
    }
}