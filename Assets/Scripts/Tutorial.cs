using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    private Animator anim;
    private bool _canAnim = true;
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
        if (other.CompareTag("Obstacle") && _canAnim == true)
        {
            _canAnim = false;
            StartCoroutine(SwipeAnimCooldown());
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

    private IEnumerator SwipeAnimCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        _canAnim = true;
    }

}
