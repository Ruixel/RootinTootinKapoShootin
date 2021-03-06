﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawnerScript : MonoBehaviour
{

    public GameObject numberOfBulletsPowerupPrefab;


    float timeBetweenSpawn = 40f;
    float timeSinceSpawn = 15f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeSinceSpawn)
        {
            timeSinceSpawn = Time.time + timeBetweenSpawn;
            Instantiate(numberOfBulletsPowerupPrefab, transform.position, Quaternion.identity);
        }
    }
}
