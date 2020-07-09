using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    // Floats
    //public static float speed = 1;

    // Vectors3
    // GameObjects
    public GameObject[] obstacles;

    // Vectors
    public Vector2 numberOfObstacles;

    // Lists
    public List<GameObject> newObstacles;

    private int _newNumberOfObstacles;

    public Vector3 speed;

    void Start()
    {
        //int newNumberOfObstacles = (int)Random.Range(numberOfObstacles.x, numberOfObstacles.y);
        InstantiateObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameManager.speed);
    }

    void FixedUpdate()
    {
        //Vector3 _speed = new Vector3 (0f, 0f, -GameManager.instance.speed);
        Vector3 _speed = new Vector3(0f, 0f, -SpeedValue.instance.speed);
        transform.Translate(_speed);
        //Debug.Log(_speed);
        speed = _speed;
        
    }

    void PositionateObstacles()
    {
        for (int i = 0; i < newObstacles.Count; i++)
        {
            //float posZMin = (-250f / newObstacles.Count) + (-250f / newObstacles.Count) * i;
            //float posZMax = (250f / newObstacles.Count) + (250f / newObstacles.Count) * i + 1;
            //newObstacles[i].transform.localPosition = new Vector3(0, 0, Random.Range(posZMin, posZMax));
            // 500
            float __Zdistance = 50 / newObstacles.Count;
            float __Zpos = __Zdistance * i;
            newObstacles[i].transform.localPosition = new Vector3(0, 0, __Zpos);
            newObstacles[i].SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("bateu");
            StartCoroutine(TrackCooldown());
        }
    }

    private void GenerateRandomNumber()
    {
        _newNumberOfObstacles = (int)Random.Range(numberOfObstacles.x, numberOfObstacles.y);
    }

    private IEnumerator TrackCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 500 * 4);
        TrackController.instance.ChangeTrack();
        foreach (var obstacle in newObstacles)
        {
            Destroy(obstacle.gameObject);
        }
        InstantiateObstacles();
    }

    private void InstantiateObstacles()
    {
        newObstacles.Clear();
        GenerateRandomNumber();

        for (int i = 0; i < _newNumberOfObstacles; i++)
        {
            newObstacles.Add(Instantiate(obstacles[Random.Range(0, obstacles.Length)], transform));
            newObstacles[i].SetActive(false);
        }

        PositionateObstacles();
        //GameManager.instance.IncreaseSpeed();
    }
}
