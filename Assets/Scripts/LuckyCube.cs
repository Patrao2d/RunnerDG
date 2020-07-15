﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyCube : MonoBehaviour
{
    public float luckyBoxRotation;
    // Start is called before the first frame update
    void Start()
    {
        int __randomPosition = Random.Range(0, 3);
        switch (__randomPosition)
        {
            case 0:
                transform.position = new Vector3(-1.5f, transform.position.y, transform.position.z);
                break;
            case 1:
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
                break;
            case 2:
                transform.position = new Vector3(1.5f, transform.position.y, transform.position.z);
                break;

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float __randomX = Random.Range((transform.rotation.x) - luckyBoxRotation, transform.rotation.x + luckyBoxRotation);
        float __randomY = Random.Range((transform.rotation.y) - luckyBoxRotation, transform.rotation.y + luckyBoxRotation);
        float __randomZ = Random.Range((transform.rotation.z) - luckyBoxRotation, transform.rotation.z + luckyBoxRotation);

        transform.Rotate(__randomX, __randomY, __randomZ, Space.Self);
    }

    private void GenerateRandomPower()
    {
        int __RandomPowerNumber = Random.Range(0, 3);
        switch (__RandomPowerNumber)
        {
            case 0:
                SpeedValue.instance.DecreaseSpeed();
                Destroy(gameObject);
            break;
            case 1:
                SpeedValue.instance.IncreaseSpeed();
                Destroy(gameObject);
                break;
            case 2:
                Player.instance.ActiveShield();
                Destroy(gameObject);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GenerateRandomPower();
        }
    }
}
