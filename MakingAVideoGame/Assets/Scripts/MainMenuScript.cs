using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject DonePanel;

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
        gamePlayUI.playerHighScore = 9999f;
        PlayerPrefs.DeleteAll();
        Debug.Log("All scores reset");
    }

    public void CloseDonePanel()
    {
        DonePanel.SetActive(false);
    }
