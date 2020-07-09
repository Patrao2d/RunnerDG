using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Player.instance.isShieldActive)
        {
            transform.Rotate(SpeedValue.instance.speed * 6, 0, 0);
        }
    }
}
