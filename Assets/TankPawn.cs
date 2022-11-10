using System;
using UnityEngine;

public class TankPawn : Pawn
{
    public Controller rocketController;
    
    protected override void SetupPlayerInput()
    {
        base.SetupPlayerInput();
        Controller.BindAction(() => Convert.ToBoolean(Input.GetAxisRaw("Fire2")), PossessToRocketController);
    }

    private void PossessToRocketController()
    {
        if (rocketController is null) return;
        
        PlayerController.Possess(rocketController);
        (rocketController.PawnControlling as RocketPawn)?.StartTimerToDestroy();
    }
}