using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelecter : MonoBehaviour
{
    public Button[] lvlButtons;
    private int _currentPage = 0;
    public GameObject[] pages;
    private int lastPage;

    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 1 > levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }

        lastPage = pages.Length - 1;
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void NextPage()
    {
        if (_currentPage >= lastPage) return;

        pages[_currentPage].SetActive(false);
        pages[_currentPage + 1].SetActive(true);
        _currentPage += 1;
    }

    public void PreviousPage()
    {
        if (_currentPage <= 0) return;

        pages[_currentPage].SetActive(false);
        pages[_currentPage - 1].SetActive(true);
        _currentPage -= 1;
    }

}
