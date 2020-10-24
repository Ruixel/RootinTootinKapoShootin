﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemySpawnerScript : MonoBehaviour
{

    float timeBetweenSpawn = 2f;
    float timeSinceSpawn = 2f;

    public GameObject flyingEnemyPrefab;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeSinceSpawn) {
            timeSinceSpawn = Time.time + timeBetweenSpawn;
            GameObject flyingEnemy = Instantiate(flyingEnemyPrefab, transform.position, Quaternion.identity);
            flyingEnemy.GetComponent<FlyingEnemyController>().player = player;

        }

    }
}