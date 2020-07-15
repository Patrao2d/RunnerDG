using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

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
            GameCanvas.instance.LoseMenu();
        }
        if (other.CompareTag("Shield"))
        {
            // Voltar aqui que isto é má logica
            Shield.instance.ExpandShield();
            Destroy(gameObject);           
        }
    }

}
