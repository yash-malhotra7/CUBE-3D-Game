using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Animator transition;

    public static bool gameIsPaused = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                ResumeGame();
            }else
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

    public void RestartThisLevel()
    {
        StartCoroutine(loadLevelAgain());
    }

    IEnumerator loadLevelAgain()
    {
        transition.SetTrigger("LevelBtnPress");

        yield return new WaitForSeconds(0.99f);

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1f;
    }
}
