using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedValue : MonoBehaviour
{
    public float speed;
    [HideInInspector]
    public float savedSpeed;
    private bool _isOnCooldown = false;

    private static SpeedValue _instance;

    public static SpeedValue instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            _instance = this;
        }

        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
    }

    private void Update()
    {
    }

    public void IncreaseSpeed()
    {
        if (_isOnCooldown == true)
        {
            return;
        }
        _isOnCooldown = true;
        savedSpeed = speed;
        speed *= 1.3f;
        Invoke("BackToNormalSpeed", 5f);
        _isOnCooldown = false;
    }

    public void DecreaseSpeed()
    {
        if (_isOnCooldown == true)
        {
            return;
        }
        _isOnCooldown = true;
        savedSpeed = speed;
        speed /= 1.3f;
        Invoke("BackToNormalSpeed", 5f);
        _isOnCooldown = false;
    }


    private void BackToNormalSpeed()
    {
        speed = savedSpeed;
    }
}
