using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public bool GameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject LevelCompleteUI;

    public void EndGame()
    {
        if(GameHasEnded == false)
        {
            GameHasEnded = true;
            Debug.Log("Game has ended");
            Invoke("Restart", restartDelay);
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CompleteLevel()
    {
        Debug.Log("Level 1 Complete!!");
    }

    public void LevelHasCompleted()
    {
        LevelCompleteUI.SetActive(true);
    }
}
