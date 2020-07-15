using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedStart : MonoBehaviour
{
    private Animator anim;

    private static DelayedStart _instance;

    public static DelayedStart instance
    {
        get { return _instance; }
    }

    private void Start()
    {
        _instance = this;
        anim = GetComponent<Animator>();
        //PlayAnim();
    }


    public void BeingStartDelay()
    {
        Time.timeScale = 0;
    }

    public void StopStartDelay()
    {
        Time.timeScale = 1;
    }

    public void PlayAnim()
    {
        anim.Play("countDown");
    }

}
