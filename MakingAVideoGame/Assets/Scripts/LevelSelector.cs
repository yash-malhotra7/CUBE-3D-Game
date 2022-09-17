using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Animator transition;

    public int level;
    public Button[] levelButtons;

    void Start()
    {
        int countPassed = 0;
        for(int i=1; i<=levelButtons.Length; i++)
        {
            if(PlayerPrefs.GetInt("passed" + i, 0) == 1)
            {
                countPassed++;
            }
        }
        int rowsOpen =1 + (countPassed/5);
        for(int i=rowsOpen*5; i<levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }

    }

    public void loadLevel()
    {
        StartCoroutine(loadLevelScene());
    }

    IEnumerator loadLevelScene()
    {
        transition.SetTrigger("ButtonClick");

        yield return new WaitForSeconds(0.99f);

        SceneManager.LoadScene(level);
    }
}
