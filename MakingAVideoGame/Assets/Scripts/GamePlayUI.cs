using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUI : MonoBehaviour
{
    public Gamemanager gamemanager;
    public PlayerMovement playerMovement;
    public EndTrigger endTrigger;

    public float countDownTime = 3f;
    public bool countDownHasFinished = false;
    public float playerTime = 00.00f;
    public float playerHighScore;
    public float medalScore;
    public int levelNumber;
    public bool playerTimeHasEnded = false;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex - 1 >= 0)
        {
            Debug.Log("Level" + (SceneManager.GetActiveScene().buildIndex));
            playerHighScore = 9999f;

            LoadHighScore();
            gamemanager.playertimeText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex - 1 >= 0)
        {
            if (!countDownHasFinished)
            {
                countDownTime -= Time.deltaTime;
                if (countDownTime < 0f)
                {
                    countDownHasFinished = true;
                    gamemanager.countDownTimerText.gameObject.SetActive(false);
                    playerMovement.movement.enabled = true;
                }
            }

            if (countDownHasFinished && !playerTimeHasEnded)
            {
                gamemanager.playertimeText.gameObject.SetActive(true);
                playerTime += Time.deltaTime;
                if (endTrigger.gameHasEnded)
                {
                    playerTimeHasEnded = true;
                }
            }

            if (playerTimeHasEnded)
            {
                if (playerTime < playerHighScore)
                {
                    playerHighScore = playerTime;
                }
                SaveHighScore();
                Debug.Log("High Score = " + playerHighScore.ToString("0.##"));
                if(playerTime < medalScore)
                {
                    PlayerPrefs.SetInt("passed" + levelNumber, 1);
                }
            }
        }

    }

    public void SaveHighScore()
    {
        if (SceneManager.GetActiveScene().buildIndex - 1 >= 0)
        {
            PlayerPrefs.SetFloat("HighScore" + SceneManager.GetActiveScene().buildIndex, playerHighScore);
        }
    }

    public void LoadHighScore()
    {if(SceneManager.GetActiveScene().buildIndex - 1 >= 0)
        {
            playerHighScore = PlayerPrefs.GetFloat("HighScore" + SceneManager.GetActiveScene().buildIndex, 9999f);
        }
    }
}
