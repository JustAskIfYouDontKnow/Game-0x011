using UnityEngine;

public class AIBrain : StateMachine
{
    [SerializeField] public StateMachine _stateMachine;

    [SerializeField] public float Speed;

    [SerializeField] public int Capacity;
    public int itemsCount = 0;


    public BaseState Base;
    public FindFoodState FindFood;
    public GoHomeState GoHome;
    public GoToPalletState GoPallete;

    void Start()
    {
        _stateMachine = gameObject.AddComponent<StateMachine>();

        Base      = new BaseState      (this, _stateMachine);
        FindFood  = new FindFoodState  (this, _stateMachine);
        GoHome    = new GoHomeState    (this, _stateMachine);
        GoPallete = new GoToPalletState(this, _stateMachine);
        
        ////SET START STATE////
        _stateMachine.SetState(GoPallete);
    }

    void FixedUpdate()
    {
        _stateMachine.UpdateState();

        ///////////////////////////////CHEAT//////////
        if (Input.GetKeyDown(KeyCode.H))
        {
            _stateMachine.SwitchState(GoHome);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _stateMachine.SwitchState(GoPallete);
        }
        //////////////////////////////CHEAT//////////
    }
}