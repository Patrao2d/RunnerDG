using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public Animator anim;

    private static FadeManager _instance;

    public static FadeManager instance
    {
        get { return _instance; }
    }

    private void Start()
    {
        _instance = this;
        anim = GetComponent<Animator>();
    }

    public void PlayFadeOut()
    {
        anim.SetTrigger("Start");
    }
}
