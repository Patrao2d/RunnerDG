using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private int _savedLevel;
    public GameObject loadingMenu;
    public GameObject creditsMenu;
    public GameObject mainMenu;

    private void Start()
    {
        Invoke("ShowBannerAd", 0.1f);
    }


    public void PlayGame()
    {
        LoadingGame();
        _savedLevel = PlayerPrefs.GetInt("levelAt");
        Debug.Log(_savedLevel);
        if (_savedLevel == 0)
        {
            SceneManager.LoadScene(1);
            AdManager.instance.HideBannerAd();
        }
        else
        {
            SceneManager.LoadScene(_savedLevel);        
            AdManager.instance.HideBannerAd();
        }
        
    }

    public void LoadingGame()
    {
        loadingMenu.SetActive(true);
    }

    private void ShowBannerAd()
    {
        AdManager.instance.PlayBannerAd();
    }

    public void CreditsMenu()
    {
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void BackToMenu()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
