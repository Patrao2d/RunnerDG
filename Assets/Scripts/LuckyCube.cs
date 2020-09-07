using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyCube : MonoBehaviour
{
    public float luckyBoxRotation;
    public float increaseSpeed;
    public float decreaseSpeed;
    private float startYPos;

    void Start()
    {
        float __randomPositionX = Random.Range(-1.5f, 1.5f);
        float __randomPositionY = Random.Range(1.25f, 2.5f);
        
        transform.position = new Vector3(__randomPositionX, __randomPositionY, transform.position.z);

        startYPos = __randomPositionY;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 1, 0, Space.Self);

        //transform.position.y = Mathf.PingPong(Time.time, )
        //transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 2), transform.position.z);
        transform.position = new Vector3(transform.position.x, Mathf.Cos(Mathf.PingPong(Time.time * 2.5f, startYPos)) -2.5f, transform.position.z);

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
