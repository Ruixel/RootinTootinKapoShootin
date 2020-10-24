using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemySpawnerScript : MonoBehaviour
{
    float timeBetweenSpawn = 4f;
    float timeSinceSpawn = 4f;

    public GameObject patrollingEnemyPrefab;
    

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
            Instantiate(patrollingEnemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
