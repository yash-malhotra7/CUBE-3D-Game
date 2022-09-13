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
    public float playerHighScore = 9999f;
    public bool playerTimeHasEnded = false;

    private void Start()
    {
        LoadHighScore();
        gamemanager.playertimeText.gameObject.SetActive(false);
    }

    void Update()
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


            if (playerTime < playerHighScore)
            {
                playerHighScore = playerTime;
            }
        }

        if(playerTimeHasEnded)
        {
            SaveHighScore();
            Debug.Log("High Score = " + playerHighScore.ToString("0.##"));
        }

    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetFloat("HighScore" + SceneManager.GetActiveScene().buildIndex, playerHighScore);
    }

    public void LoadHighScore()
    {
        playerHighScore = PlayerPrefs.GetFloat("HighScore" + SceneManager.GetActiveScene().buildIndex, 99999f);
    }
}
