using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(SpeedValue.instance.speed * 11, 0, 0);
    }
}
