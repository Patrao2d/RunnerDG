using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyCube : MonoBehaviour
{
    public float luckyBoxRotation;
    public float increaseSpeed;
    public float decreaseSpeed;

    void Start()
    {
        float __randomPosition = Random.Range(-1.5f, 1.5f);
        transform.position = transform.position = new Vector3(__randomPosition, transform.position.y, transform.position.z);
        /*switch (__randomPosition)
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

        }*/
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
        if (SpeedValue.instance.isOnHyperSpeed == true)
        {
            __RandomPowerNumber = 0;
        }
        switch (__RandomPowerNumber)
        {
            case 0:
                SpeedValue.instance.DecreaseSpeed(decreaseSpeed);
                Destroy(gameObject);
            break;
            case 1:
                SpeedValue.instance.IncreaseSpeed(increaseSpeed);
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
