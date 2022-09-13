using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GamePlayUI gamePlayUI;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetScores()
    {
        gamePlayUI.playerHighScore = 0f;
        PlayerPrefs.DeleteAll();
        Debug.Log("All scores reset");
    }
}
