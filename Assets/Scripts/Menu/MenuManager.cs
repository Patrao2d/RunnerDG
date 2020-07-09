using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject levelSelect;

    public GameObject normal;
    public GameObject hard;
    public GameObject nightmare;

    [HideInInspector]
    public int dificultyLevel; // 0 - normal , 1 - hard , 2 - nightmare

    private static MenuManager _instance;

    public static MenuManager instance
    {
        get { return _instance; }
    }

    private void Start()
    {
        _instance = this;
    }

    public void GoToNormal()
    {  
        startMenu.SetActive(false);
        levelSelect.SetActive(true);       
        normal.SetActive(true);
        dificultyLevel = 0;
        Invoke("InvokeNormal", 0.01f); 
    }

    public void GoToHard()
    {
        startMenu.SetActive(false);
        levelSelect.SetActive(true);
        hard.SetActive(true);
        dificultyLevel = 1;
        Invoke("InvokeHard", 0.01f);
    }

    public void GoToNightmare()
    {
        startMenu.SetActive(false);
        levelSelect.SetActive(true);
        nightmare.SetActive(true);
        dificultyLevel = 2;
        Invoke("InvokeNightmare", 0.01f);
    }

    public void BackToMain()
    {
        startMenu.SetActive(true);
        levelSelect.SetActive(false);
        normal.SetActive(false);
        hard.SetActive(false);
        nightmare.SetActive(false);
    }

    public void InvokeNormal()
    {
        LevelSelecter.instance.LoadNormal();
    }

    public void InvokeHard()
    {
        LevelSelecter.instance.LoadHard();
    }

    public void InvokeNightmare()
    {
        LevelSelecter.instance.LoadNightMare();
    }
}
