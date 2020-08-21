using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private bool _canCollide = true;

    public enum swipeDirection { sides, up, down };
    public swipeDirection dodgeDirection;

    private static Obstacle _instance;

    public static Obstacle instance
    {
        get { return _instance; }
    }

    private void Start()
    {
        _instance = this;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && _canCollide)
        {
            //Debug.Log("sup");
            _canCollide = false;
            GameManager.instance.countPlayersAlive();
            StartCoroutine(CollisionCooldown());
        }
    }


    private IEnumerator CollisionCooldown()
    {
        yield return new WaitForSeconds(0.01f);
        _canCollide = true;
    }*/
}
