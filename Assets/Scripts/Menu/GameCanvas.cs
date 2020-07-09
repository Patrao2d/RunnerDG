using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCanvas : MonoBehaviour
{
    // GameObjects
    public GameObject winMenu;
    public GameObject pauseMenu;
    public GameObject loseMenu;

    // Int
    public int nextSceneLoad;

    // Bools
    private bool _isGamePaused = false;
    private bool _endGame =false;

    private static GameCanvas _instance;

    public static GameCanvas instance
    {
        get { return _instance; }
    }
    void Start()
    {
        _instance = this;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.timeScale);

        if (_endGame && Time.timeScale >= 0.1f)
        {
            Time.timeScale -= 0.025f;
        }
        else if (_endGame && Time.timeScale < 0.1f)
        {
            Time.timeScale = 0;
        }
    }

    public void MainMenu()
    {
        // Goto main menu
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void NextLevel()
    {

        // ultimo nivel do build index
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Debug.Log("yaya");
        }
        else if (MenuManager.instance.dificultyLevel == 0)
        {
            SceneManager.LoadScene(nextSceneLoad);

            if (nextSceneLoad > PlayerPrefs.GetInt("levelAtNormal"))
            {
                PlayerPrefs.SetInt("levelAtNormal", nextSceneLoad);
                Debug.Log("normal");
            }
        }
        else if (MenuManager.instance.dificultyLevel == 1)
        {
            SceneManager.LoadScene(nextSceneLoad);

            if (nextSceneLoad > PlayerPrefs.GetInt("levelAtHard"))
            {
                PlayerPrefs.SetInt("levelAtHard", nextSceneLoad);
                Debug.Log("hard");
            }
        }
        else if (MenuManager.instance.dificultyLevel == 2)
        {
            SceneManager.LoadScene(nextSceneLoad);

            if (nextSceneLoad > PlayerPrefs.GetInt("levelAtNightmare"))
            {
                PlayerPrefs.SetInt("levelAtNightmare", nextSceneLoad);
                Debug.Log("nightmare");
            }
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void GetShield()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AdManager.instance.PlayRewardAd();
        // Force AD
        // Add shield
        
    }

    public void WinMenu()
    {
        winMenu.SetActive(true);
        SlowdownPause();       
    }

    public void LoseMenu()
    {
        loseMenu.SetActive(true);
        SlowdownPause();
    }

    public void PauseButton()
    {
        if (_isGamePaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            _isGamePaused = !_isGamePaused;
        }
        else
        { 
            pauseMenu.SetActive(true);
            Time.timeScale = 0;   
            _isGamePaused = !_isGamePaused;
        }
    }

    public void CallNextLevelAd()
    {
        int __chanceToAd = Random.Range(1, 3);
        if (__chanceToAd == 1)
        {
            AdManager.instance.PlayInterstitialAd();
        }
        else
        {
            NextLevel();
            Time.timeScale = 1;
        }

        //AdManager.instance.PlayInterstitialAd();
    }

    private void SlowdownPause()
    {
        _endGame = true;
    }
}
