using System.Collections;
using UnityEngine;

public class RocketPawn : Pawn
{
    public Controller tankController;

    public void StartTimerToDestroy()
    {
        StartCoroutine(TimerToDestroy());
    }

    private IEnumerator TimerToDestroy()
    {
        yield return new WaitForSeconds(3.0f);
        
        PlayerController.Possess(tankController);
        
        Destroy(gameObject);
    }
}