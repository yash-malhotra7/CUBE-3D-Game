using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Gamemanager : MonoBehaviour
{

    public GamePlayUI gamePlayUI;

    public GameObject LevelCompleteUI;
    public GameObject GameOver;
    public GameObject DonePanel;

    public bool GameHasEnded = false;
    public float restartDelay = 1f;
    public float coutDownTime = 3f;
    public Text countDownTimerText;
    public Text playertimeText;
    public Text highScoreText;
    public Text medalScoreText;

    private void Update()
    { if (SceneManager.GetActiveScene().buildIndex - 1 >= 0)
        {
            countDownTimerText.text = gamePlayUI.countDownTime.ToString("0");
            playertimeText.text = gamePlayUI.playerTime.ToString("0.##");
            if (gamePlayUI.playerHighScore != 9999f)
            {
                highScoreText.text = gamePlayUI.playerHighScore.ToString("Player: " + "0.##");
            }
            medalScoreText.text = gamePlayUI.medalScore.ToString("Medal: " + "0.##");
        }
    }

    public void PlayerFell()
    {
        GameOver.SetActive(true);
    }

    public void EndGame()
    {
        if(GameHasEnded == false)
        {
            GameHasEnded = true;
        }
        
    }

    public void LevelHasCompleted()
    {
        LevelCompleteUI.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
