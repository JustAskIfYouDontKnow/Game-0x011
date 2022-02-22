using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEditor.VersionControl;
using UnityEngine.Serialization;

public class AIBrain : StateMachine
{
    [SerializeField] public StateMachine stateMachine;
    [SerializeField] public float speed;
    [SerializeField] public int itemCapacity;
    [SerializeField] public int itemsCount = 0;
    [SerializeField] public List<Item> inventory;


    public BaseState Base;
    public FindFoodState FindFood;
    public GoHomeState GoHome;
    public GoToPalletState GoPallete;

    void Start()
    {
        stateMachine = gameObject.AddComponent<StateMachine>();
        
        inventory = new List<Item>(itemCapacity);
        
        Base = new BaseState(this, stateMachine);
        FindFood = new FindFoodState(this, stateMachine);
        GoHome = new GoHomeState(this, stateMachine);
        GoPallete = new GoToPalletState(this, stateMachine);

        ////SET START STATE////
        stateMachine.SetState(Base);
    }

    void FixedUpdate()
    {
        stateMachine.UpdateState();
    }

    enum States
    {
        Base = 0,
        FindFood = 1,
        GoHome = 2,
        GoPallete = 3,
    }
    
    public void SetStateWithButton(int stateID)
    {
        switch (stateID)
        {
            case (int) States.Base:
                stateMachine.SetState(Base);
                break;
            case (int) States.FindFood:
                stateMachine.SwitchState(FindFood);
                break;
            case (int) States.GoHome:
                stateMachine.SwitchState(GoHome);
                break;
            case (int) States.GoPallete:
                stateMachine.SwitchState(GoPallete);
                break;
        }
    }
}