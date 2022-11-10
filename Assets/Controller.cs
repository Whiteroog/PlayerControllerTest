using System;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Pawn PawnControlling { private set; get; }
    
    private Dictionary<Func<float>, Action<float>> _inputAxis = new();
    private Dictionary<Func<bool>, Action> _inputAction = new();

    private void Start()
    {
        PawnControlling = GetComponent<Pawn>();
    }

    public void BindAxis(Func<float> inputAxis, Action<float> funcAxis)
    {
        _inputAxis.Add(inputAxis, funcAxis);
    }
    
    public void BindAction(Func<bool> inputAction, Action funcAction)
    {
        _inputAction.Add(inputAction, funcAction);
    }

    public void InputListener()
    {
        foreach (var axis in _inputAxis)
        {
            axis.Value.Invoke(axis.Key.Invoke());
        }
        
        foreach (var action in _inputAction)
        {
            if(action.Key.Invoke())
                action.Value.Invoke();
        }
    }
}