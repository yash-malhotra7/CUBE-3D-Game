using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    public GamePlayUI gamePlayUI;

    public GameObject Donepanel;
    public GameObject resetPanel;
    public GameObject MainMenuPanel;
    public GameObject CampaignPanel;
    public GameObject SettingsPanel;
    public GameObject CampaignBtn;
    public GameObject SettingsBtn;
    public GameObject QuitBtn;
    public GameObject image;
    public Animator transition;


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

    public void loadCampaign()
    {
        StartCoroutine(loadCampaignPanel());
    }

    IEnumerator loadCampaignPanel()
    {
        transition.SetTrigger("ButtonClick");

        yield return new WaitForSeconds(1);

        CampaignPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void backFromCampaign()
    {
        StartCoroutine(backFromCampaignPanel());
    }

    IEnumerator backFromCampaignPanel()
    {
        transition.SetTrigger("ButtonClick");

        yield return new WaitForSeconds(1);

        CampaignPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void loadSettings()
    {
        StartCoroutine(loadSettingsPanel());
    }

    IEnumerator loadSettingsPanel()
    {
        transition.SetTrigger("ButtonClick");

        yield return new WaitForSeconds(1);

        SettingsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void backFromSettings()
    {
        StartCoroutine(backFromSettingsPanel());
    }

    IEnumerator backFromSettingsPanel()
    {
        transition.SetTrigger("ButtonClick");

        yield return new WaitForSeconds(1);

        SettingsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
}
