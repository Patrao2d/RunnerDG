using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !Player.instance.isInvulnerable)
        {
            Debug.Log("rip");
            GameManager.instance.ResetScene();
        }
    }

}
