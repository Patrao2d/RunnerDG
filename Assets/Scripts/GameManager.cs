using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Range(0,1000)]
    public int nPlayers;
    [Range(0,100)]
    public int deadChance;
    public TextMeshProUGUI playerLeft;
    public TextMeshProUGUI timerText;

    private char splitter = ':';
    public float timer;
    private bool _active;

    private static GameManager _instance;

    public static GameManager instance
    {
        get { return _instance; }
    }

    void Start()
    {
        _instance = this;
        playerLeft.text = nPlayers.ToString();
        _active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            countPlayersAlive();
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            //PlayerPrefs.DeleteKey("levelAtNormal");
            PlayerPrefs.DeleteAll();
        }
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            PlayerPrefs.SetInt("levelAtNormal", 10);
            PlayerPrefs.SetInt("levelAtHard", 5);
            PlayerPrefs.SetInt("levelAtNightmare", 3);
        }

        if (_active)
        {
            timer += Time.deltaTime;
            UpdateTimer();
        }

    }

    public void countPlayersAlive()
    {
        for (int i = 0; i < nPlayers; i++)
        {
            int __randomNumber = Random.Range(0, 100);
            if (__randomNumber < deadChance)
            {
                nPlayers--;
            }
        }
        if (nPlayers == 1)
        {
            GameCanvas.instance.WinMenu();
            Player.instance.ChangeVulnerability();
        }
        playerLeft.text = nPlayers.ToString();

    }

    public void ResetScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    private void UpdateTimer()
    {
        float __seconds = (timer % 60);
        float __minutes = ((int)timer / 60) % 60;
        timerText.text = __minutes.ToString("00") + splitter + __seconds.ToString("00");
    }

}
