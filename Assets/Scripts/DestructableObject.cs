﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    public int forward = 1;
    void Start()
    {
        StartCoroutine(HyperDestruction());
    }


    private void FixedUpdate()
    {
        Vector3 _speed = new Vector3(0f, 0f, -SpeedValue.instance.speed / 1.5f);
        transform.Translate(_speed * forward);
    }

    public IEnumerator HyperDestruction()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        Destroy(gameObject);
    }
}
