using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    public GamePlayUI gamePlayUI;
    public GameObject Donepanel;
    public GameObject resetPanel;

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

    public void RemoveDonePanel()
    {
        Donepanel.SetActive(false);
    }
}
