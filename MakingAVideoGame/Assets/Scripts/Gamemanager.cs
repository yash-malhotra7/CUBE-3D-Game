using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Gamemanager : MonoBehaviour
{

    public GamePlayUI gamePlayUI;
    public GameObject pauseMenuUI;


    public GameObject LevelCompleteUI;
    public GameObject GameOver;
    public GameObject DonePanel;
    public bool GameHasEnded = false;
    public static bool gameIsPaused = false;
    public float restartDelay = 1f;
    public float coutDownTime = 3f;
    public Text countDownTimerText;
    public Text playertimeText;
    public Text highScoreText;
    public Text GoldMedalText;
    public Animator transition;

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex - 1 >= 0)
        {
            countDownTimerText.text = gamePlayUI.countDownTime.ToString("0");
            playertimeText.text = gamePlayUI.playerTime.ToString("0.##");
            if (gamePlayUI.playerHighScore != 9999f)
            {
                highScoreText.text = gamePlayUI.playerHighScore.ToString("Player: " + "0.##");
            }
            GoldMedalText.text = gamePlayUI.GoldMedal.ToString("Medal: " + "0.##");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuOpen()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
        SceneManager.LoadScene(0);
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

    public void RestartThisLevel()
    {
        StartCoroutine(loadLevelAgain());
    }

    IEnumerator loadLevelAgain()
    {
        transition.SetTrigger("LevelBtnPress");

        yield return new WaitForSeconds(0.99f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        LevelCompleteUI.SetActive(false);
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadMainMenuScene());
    }

    IEnumerator LoadMainMenuScene()
    {
        transition.SetTrigger("LevelBtnPress");

        yield return new WaitForSeconds(0.99f);

        SceneManager.LoadScene(0);
        LevelCompleteUI.SetActive(false);
        gameIsPaused = false;
    }
}
