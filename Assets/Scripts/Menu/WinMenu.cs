using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration;
    public GameObject confetis;

    void Start()
    {
        confetis.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        canvasGroup.alpha = Mathf.Lerp(0, 1, Time.unscaledTime / fadeDuration);
    }
}
