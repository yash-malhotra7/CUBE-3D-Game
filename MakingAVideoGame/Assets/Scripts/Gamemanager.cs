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

    public bool GameHasEnded = false;
    public float restartDelay = 1f;
    public float coutDownTime = 3f;
    public Text countDownTimerText;
    public Text playertimeText;
    public Text highScoreText;

    private void Update()
    {
        countDownTimerText.text = gamePlayUI.countDownTime.ToString("0");
        playertimeText.text = gamePlayUI.playerTime.ToString("0.##");
        if (gamePlayUI.playerHighScore != 9999f)
        {
            highScoreText.text = gamePlayUI.playerHighScore.ToString("0.###");
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

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
