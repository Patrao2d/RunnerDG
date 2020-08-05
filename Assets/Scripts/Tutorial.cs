using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    private Animator anim;
    public enum swipeDirection {up, down, left, right };
    public swipeDirection swipe;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        if (swipe == swipeDirection.up)
        {
            anim.SetTrigger("up");
        }
        else if (swipe == swipeDirection.down)
        {
            anim.SetTrigger("down");
        }
        else if (swipe == swipeDirection.left)
        {
            anim.SetTrigger("left");
        }
        else
        {
            anim.SetTrigger("right");
        }
    }
}
