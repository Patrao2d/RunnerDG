using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    private Animator anim;
    //public enum swipeDirection {up, down, left, right };
    //public swipeDirection swipe;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            switch (other.GetComponent<Obstacle>().dodgeDirection)
            {
                case Obstacle.swipeDirection.sides:
                    if (other.GetComponent<Transform>().transform.position.x < 0)
                    {
                        anim.SetTrigger("right");
                    }
                    else
                    {
                        anim.SetTrigger("left");
                    }
                    break;
                case Obstacle.swipeDirection.up:
                    anim.SetTrigger("up");
                    break;
                case Obstacle.swipeDirection.down:
                    anim.SetTrigger("down");
                    break;
                default:
                    break;
            }
        }
    }

    public void PauseToTutorial()
    {
        Time.timeScale = 0;
    }

    public void UnPauseToTutorial()
    {
        Time.timeScale = 1.0f;
    }

}
