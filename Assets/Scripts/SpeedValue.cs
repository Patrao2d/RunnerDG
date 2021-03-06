﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedValue : MonoBehaviour
{
    public float speed;
    [HideInInspector]
    public float savedSpeed;
    public float maxSpeed;
    public float TimeToReachMaxSpeed;
    private bool _isOnCooldown = false;
    public bool isOnHyperSpeed = false;
    public double decimalSpeed = 0;

    private float _cenaRandom = 0.0f;

    private static SpeedValue _instance;

    public static SpeedValue instance
    {
        get { return _instance; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
    }

    private void Update()
    {
            if (GameCanvas.instance.endGame == true)
            {
                return;
            }
            speed = Mathf.SmoothDamp(speed, maxSpeed, ref _cenaRandom, TimeToReachMaxSpeed);

            decimalSpeed = System.Math.Round(speed, 1);
    }

    public void IncreaseSpeed(float __speed)
    {
        if (_isOnCooldown == true)
        {
            return;
        }
        _isOnCooldown = true;
        if (isOnHyperSpeed == false)
        {
            savedSpeed = speed;
        }
        //speed *= 1.3f;
        speed += __speed;
        Invoke("BackToNormalSpeed", 5f);
        _isOnCooldown = false;
        Player.instance.spriteRenderer.sprite = Player.instance.speedUp;
    }

    public void DecreaseSpeed(float __speed)
    {
        if (_isOnCooldown == true)
        {
            return;
        }
        _isOnCooldown = true;
        if (isOnHyperSpeed == false)
        {
            savedSpeed = speed;
        }        
        //speed /= 1.3f;
        speed -= __speed;
        Invoke("BackToNormalSpeed", 5f);
        _isOnCooldown = false;
        Player.instance.spriteRenderer.sprite = Player.instance.speedDown;
    }


    private void BackToNormalSpeed()
    {
        speed = savedSpeed;
        Player.instance.spriteRenderer.sprite = Player.instance.none;
    }

    public void HyperSpeed()
    {
        isOnHyperSpeed = true;
        savedSpeed = speed;
        //Invoke("BackToNormalSpeed", 1f);
        StartCoroutine(EndHyperSpeed());
    }

    IEnumerator EndHyperSpeed()
    {
        yield return new WaitForSeconds(2f);
        speed = savedSpeed;
        yield return new WaitForSeconds(0.4f);
        isOnHyperSpeed = false;
    }
}
