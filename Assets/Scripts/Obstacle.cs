using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private bool _canCollide = true;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(_canCollide);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && _canCollide)
        {
            //Debug.Log("sup");
            _canCollide = false;
            StartCoroutine(CollisionCooldown());
            GameManager.instance.countPlayersAlive();
        }
    }


    private IEnumerator CollisionCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        _canCollide = true;
    }
}
