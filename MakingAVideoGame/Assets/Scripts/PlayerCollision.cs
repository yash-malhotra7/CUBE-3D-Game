using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public GamePlayUI gamePlayUI;

    public GameObject GameOverPanel;

    void OnCollisionEnter(Collision collision)
    {
        
        if(collision.collider.tag == "Mountains")
        {
            if (!gamePlayUI.playerTimeHasEnded)
            {
                movement.enabled = false;
                GameOverPanel.SetActive(true);
            }
        }
    }
}
