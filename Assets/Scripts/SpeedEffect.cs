using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEffect : MonoBehaviour
{
    public ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var __main = particleSystem.main;
        //particleSystem.main.startSpeed = 30 * SpeedValue.instance.speed;
        __main.startSpeed = 20 * SpeedValue.instance.speed;
        __main.maxParticles = Mathf.RoundToInt(150 * SpeedValue.instance.speed);
    }
}
