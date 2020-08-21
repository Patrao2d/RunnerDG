using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardRandomPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float __randomXPos = Random.Range(-1.5f, 1.5f);
        transform.position = new Vector3(__randomXPos, transform.position.y, transform.position.z);
    }

}
