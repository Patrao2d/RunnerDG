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
    private bool _wonGame =false;

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

        if (_wonGame && Time.timeScale >= 0.1f)
        {
            Time.timeScale -= 0.025f;
        }
        else if (_wonGame && Time.timeScale < 0.1f)
        {
            Time.timeScale = 0;
        }
    }

    public void MainMenu()
    {
        // Goto main menu
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        // ultimo nivel do build index
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Debug.Log("yaya");
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

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GetShield()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    private void SlowdownPause()
    {
        _wonGame = true;
    }
}
