using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public GameObject destructedObject;

    // Update is called once per frame
    void Update()
    {
        transform.localScale = transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Player.instance.isInvulnerable)
        return;

        if (other.CompareTag("Player"))
        {
            if (Player.instance.isShieldActive)
            {
                return;
            }
            else if (SpeedValue.instance.isOnHyperSpeed == true)
            {
                HyperImpact();   
            }
            else
            {
                GameCanvas.instance.LoseMenu();
            }
            
        }
        if (other.CompareTag("Shield"))
        {
            // Voltar aqui que isto é má logica
            Shield.instance.ExpandShield();
            Destroy(gameObject);           
        }
    }

    private void HyperImpact()
    {
        Instantiate(destructedObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
