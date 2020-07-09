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

    private static GameManager _instance;

    public static GameManager instance
    {
        get { return _instance; }
    }

    void Start()
    {
        _instance = this;
        //nPlayers = 100;
        playerLeft.text = nPlayers.ToString();
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
        }
        playerLeft.text = nPlayers.ToString();

    }

    public void ResetScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    /*public void IncreaseSpeed()
    {
        speed *= 1.01f;
    }*/
}
