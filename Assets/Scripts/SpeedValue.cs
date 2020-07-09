using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedValue : MonoBehaviour
{
    public float speed;

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

}
