using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider slider;
    public float totalLevelDuration;

    private char splitter = ':';
    public float timer;
    private bool _active;
    private bool _gameOver = false;
    public bool showFinishLine = false;

    private static GameManager _instance;

    public static GameManager instance
    {
        get { return _instance; }
    }

    void Start()
    {
        _instance = this;
        _active = true;
        Time.timeScale = 1;
        slider.maxValue = totalLevelDuration;
        StartCoroutine(HideBannerAd());
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            PlayerPrefs.SetInt("levelAt", 10);
        }

        if (_active)
        {
            timer += Time.deltaTime;
            UpdateTimer();
        }

    }

    public void ResetScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    private void UpdateTimer()
    {
        /*float __seconds = (timer % 60);
        float __minutes = ((int)timer / 60) % 60;
        timerText.text = __minutes.ToString("00") + splitter + __seconds.ToString("00");*/
        slider.value = timer;
        if (slider.value >= slider.maxValue && _gameOver == false)
        {
            _gameOver = true;
            GameCanvas.instance.WinMenu();
            Player.instance.ChangeVulnerability();
        }

        if (totalLevelDuration - timer <= 3.9f / SpeedValue.instance.speed  && showFinishLine == false)
        {
            showFinishLine = true;
            TrackController.instance.FinishTrack();
        }
    }

    private IEnumerator HideBannerAd()
    {
        yield return new WaitForSeconds(0.5f);
        AdManager.instance.HideBannerAd();
    }

}
