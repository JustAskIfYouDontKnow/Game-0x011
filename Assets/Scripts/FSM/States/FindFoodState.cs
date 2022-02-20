using UnityEngine;
public class FindFoodState : State
{
    public Item[] items;
    private int _itemIndex;
    public GameObject takedObject;


    public FindFoodState(AIBrain ai, StateMachine stateMachine) : base(ai, stateMachine) {}
    public override void EnterState()
    {
        Debug.Log("Enter in: [" + this + "]");

        _itemIndex = 0;
        items = Object.FindObjectsOfType<Item>();

        //Если ничего не нашли на сцене, то стоим
        if (items.Length == 0)
        {
            stateMachine.SwitchState(ai.Base);
        }
    }

    public override void UpdateState()
    {
        
        var AIPos = ai.transform.position;
        //Если есть место в инвентаре, и на сцене в принцпе хватает объектов для поиска
        if (ai.Capacity > ai.itemsCount && _itemIndex < items.Length)
        {
            var targetPos = items[_itemIndex].transform.position;
            //То двигаемся к объекту
            if (Vector3.Distance(AIPos, targetPos) > 0.2)
            {
                ai.transform.position = Vector3.MoveTowards(AIPos, targetPos, Time.deltaTime * ai.Speed);
            }
            //Как дойдем - удаляем его со сцены, кидаем в инвентарь и движемся к следующему
            else
            {
                ai.itemsCount++;
                takedObject = items[_itemIndex].gameObject;
                Object.Destroy(items[_itemIndex].gameObject);
                _itemIndex++;
            }
        }
        else
        {
            _itemIndex = 0;
            stateMachine.SwitchState(ai.GoHome);
        }
        Debug.Log("Update:[" + this + "]");
    }
    


    public override void ExitState()
    {
        Debug.Log("Exit in: [" + this + "]");
    }
}