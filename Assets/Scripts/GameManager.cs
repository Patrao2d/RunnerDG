using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float speed;
    public int nPlayers;
    public TextMeshProUGUI playerLeft;

    private static GameManager _instance;

    public static GameManager instance
    {
        get { return _instance; }
    }

    void Start()
    {
        _instance = this;
        nPlayers = 100;
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
            PlayerPrefs.DeleteKey("levelAt");
        }
    }

    public void countPlayersAlive()
    {
        for (int i = 0; i < nPlayers; i++)
        {
            int __randomNumber = Random.Range(0, 100);
            if (__randomNumber < 50)
            {
                nPlayers--;
            }
        }
        if (nPlayers == 1)
        {
            Debug.Log("Win crl !");
            // Pause
            // Open win menu
            GameCanvas.instance.WinMenu();
        }
        playerLeft.text = nPlayers.ToString();
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
