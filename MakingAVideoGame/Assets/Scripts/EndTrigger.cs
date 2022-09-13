using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public Gamemanager gameManager;
    public bool gameHasEnded = false;
    private void OnTriggerEnter()
    {
        gameManager.LevelHasCompleted();
        gameHasEnded = true;
    }
}
