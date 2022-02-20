using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statePlayerText;
    [SerializeField] private TextMeshProUGUI capacityText;
    private AIBrain _ai;

    public void Start()
    {
        _ai = FindObjectOfType<AIBrain>();
    }

    public void FixedUpdate()
    {
       statePlayerText.text = _ai._stateMachine.GetCurrentState();
       capacityText.text = "Capacity:" + _ai.Capacity + "/" + _ai.itemsCount;
    }
}