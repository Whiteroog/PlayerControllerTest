using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Controller startPlayingController;
    
    private static Controller _pawnControllingByPlayer;

    private delegate void InputHandler();
    
    private static InputHandler _inputListener;
    private static event InputHandler InputListener
    {
        add
        {
            _inputListener += value;
            _pawnControllingByPlayer.PawnControlling.SetSelect(true);
        }
        remove
        {
            _pawnControllingByPlayer.PawnControlling.SetSelect(false);
            _inputListener -= value;
        }
    }

    private void Start()
    {
        if(startPlayingController is not null)
            Possess(startPlayingController);
    }

    public static void Possess(Controller controller)
    {
        UnPossess();
        
        _pawnControllingByPlayer = controller;
        InputListener += _pawnControllingByPlayer.InputListener;
    }

    public static void UnPossess()
    {
        if (_inputListener is null) return;

        InputListener -= _pawnControllingByPlayer.InputListener;
        _pawnControllingByPlayer = null;
    }

    private void Update()
    {
        _inputListener?.Invoke();
    }
}
