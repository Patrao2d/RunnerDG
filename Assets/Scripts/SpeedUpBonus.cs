using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBonus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpeedValue.instance.HyperSpeed();
            SpeedValue.instance.speed *= 2;
        }
    }
}
