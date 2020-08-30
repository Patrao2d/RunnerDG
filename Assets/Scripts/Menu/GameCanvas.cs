using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameCanvas : MonoBehaviour
{
    // GameObjects
    public GameObject winMenu;
    public GameObject pauseMenu;
    public GameObject loseMenu;

    // Int
    public int nextSceneLoad;

    // Bools
    [HideInInspector]
    public bool isGamePaused = false;
    [HideInInspector]
    public bool endGame = false;
    private bool winGame = true;

    public Button pauseButton;

    public Sprite pauseImage;
    public Sprite unpauseImage;

    public TextMeshProUGUI levelText;
    private int currentLevel;

    private static GameCanvas _instance;

    public static GameCanvas instance
    {
        get { return _instance; }
    }
    void Start()
    {
        _instance = this;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        levelText.text = currentLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (endGame && SpeedValue.instance.speed > 0.4f)
        {
            SpeedValue.instance.speed -= 0.10f;
        }
        else if (endGame && SpeedValue.instance.speed <= 0.4f)
        {
            //Time.timeScale = 0;
            SpeedValue.instance.speed = 0.0f;
            if (winGame == true)
            {
                RotatePlayer.instance.WinAnim();
            }
            else
            {
                RotatePlayer.instance.LoseAnim();
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        StartCoroutine(FadeToNextLevel());
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
    }

    public void WinMenu()
    {
        TrackController.instance.ClearAllTracks();
        winMenu.SetActive(true);
        SlowdownPause();
        Time.timeScale = 0.89f;
        winGame = true;
    }

    public void LoseMenu()
    {
        loseMenu.SetActive(true);
        SlowdownPause();
        Time.timeScale = 0.89f;
        winGame = false;
    }

    public void PauseButton()
    {
        if (isGamePaused)
        {
            pauseMenu.SetActive(false);
            pauseButton.GetComponent<Image>().sprite = unpauseImage;
            DelayedStart.instance.PlayAnim();
            isGamePaused = !isGamePaused;
            Time.timeScale = 1;
        }
        else if (!isGamePaused && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);           
            pauseButton.GetComponent<Image>().sprite = pauseImage;         
            isGamePaused = !isGamePaused;
        }
    }

    public void CallNextLevelAd()
    {
        int __chanceToAd = Random.Range(1, 7);
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
        endGame = true;
    }


    IEnumerator FadeToNextLevel()
    {
        FadeManager.instance.PlayFadeOut();

        yield return new WaitForSecondsRealtime(0.35f);

        if (SceneManager.GetActiveScene().buildIndex == 37)
        {
            SceneManager.LoadScene(nextSceneLoad);
            Debug.Log("current last level");
        }
        else 
        {
            SceneManager.LoadScene(nextSceneLoad);
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }
    }
}
