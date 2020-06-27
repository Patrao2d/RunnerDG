using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static float speed;
    private int _nPlayers;
    public TextMeshProUGUI playerLeft;

    private static GameManager _instance;

    public static GameManager instance
    {
        get { return _instance; }
    }

    void Start()
    {
        _instance = this;
        speed = 1;
        _nPlayers = 99;
        playerLeft.text = _nPlayers.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            countPlayersAlive();
        }
    }

    public void countPlayersAlive()
    {
        for (int i = 0; i < _nPlayers; i++)
        {
            int __randomNumber = Random.Range(0, 100);
            if (__randomNumber < 50)
            {
                _nPlayers--;
            }
        }
        if (_nPlayers == 0)
        {
            Debug.Log("Win crl !");
            // Pause
            // Open win menu
            GameCanvas.instance.WinMenu();
        }
        playerLeft.text = _nPlayers.ToString();
        //Debug.Log(playerLeft.text);
        //Debug.Log(_nPlayers);
    }

    public void ResetScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void IncreaseSpeed()
    {
        speed *= 1.01f;
    }
}
