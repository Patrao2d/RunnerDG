using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelecter : MonoBehaviour
{
    public Button[] lvlButtons;
    public Button nxtPageButton;
    private int _currentPage = 0;
    public GameObject[] pages;
    private int lastPage;
    private int _levelAtNormal;
    private int _levelAtHard;
    private int _levelAtNightmare;

    private static LevelSelecter _instance;

    public static LevelSelecter instance
    {
        get { return _instance; }
    }

    void Start()
    {
        _instance = this;

        /* if (MenuManager.instance.dificultyLevel == 0)
         {
             int __levelAtNormal = PlayerPrefs.GetInt("levelAtNormal", 1);

             for (int i = 0; i < lvlButtons.Length; i++)
             {
                 if (i + 1 > __levelAtNormal)
                 {
                     lvlButtons[i].interactable = false;
                 }
             }
         }
         else if (MenuManager.instance.dificultyLevel == 1)
         {
             int __levelAtHard = PlayerPrefs.GetInt("levelAtHard", 1);

             for (int i = 0; i < lvlButtons.Length; i++)
             {
                 if (i + 1 > __levelAtHard)
                 {
                     lvlButtons[i].interactable = false;
                 }
             }
         }
         else
         {
             int __levelAtNightmare = PlayerPrefs.GetInt("levelAtNightmare", 1);

             for (int i = 0; i < lvlButtons.Length; i++)
             {
                 if (i + 1 > __levelAtNightmare)
                 {
                     lvlButtons[i].interactable = false;
                 }
             }
         }*/



        lastPage = pages.Length - 1;
    }

    public void LoadLevel(int level)
    {
        FadeManager.instance.PlayFadeOut();
        switch (MenuManager.instance.dificultyLevel)
        {
            case 0:
                SpeedValue.instance.speed = 1;
                break;             
            case 1:
                SpeedValue.instance.speed = 1.3f;
                break;
            case 2:
                SpeedValue.instance.speed = 1.6f;
                break;

        }
        SceneManager.LoadScene(level);
    }

    public void NextPage()
    {
        if (_currentPage >= lastPage) return;

        pages[_currentPage].SetActive(false);
        pages[_currentPage + 1].SetActive(true);
        _currentPage += 1;

        if (_currentPage != lastPage) return;
        nxtPageButton.interactable = false;
    }

    public void PreviousPage()
    {
        if (_currentPage <= 0)
        {
            MenuManager.instance.BackToMain();
        }
        else
        {
            pages[_currentPage].SetActive(false);
            pages[_currentPage - 1].SetActive(true);
            _currentPage -= 1;
        }
        if (_currentPage == lastPage) return;
        nxtPageButton.interactable = true;
    }

    public void LoadNormal()
    {
        _levelAtNormal = PlayerPrefs.GetInt("levelAtNormal", 1);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 1 > _levelAtNormal)
            {
                lvlButtons[i].interactable = false;
            }
            else
            {
                lvlButtons[i].interactable = true;
            }
        }
    }

    public void LoadHard()
    {
        _levelAtHard = PlayerPrefs.GetInt("levelAtHard", 1);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 1 > _levelAtHard)
            {
                lvlButtons[i].interactable = false;
            }
            else
            {
                lvlButtons[i].interactable = true;
            }
        }
    }

    public void LoadNightMare()
    {
        _levelAtNightmare = PlayerPrefs.GetInt("levelAtNightmare", 1);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 1 > _levelAtNightmare)
            {
                lvlButtons[i].interactable = false;
            }
            else
            {
                lvlButtons[i].interactable = true;
            }
        }
    }

}
