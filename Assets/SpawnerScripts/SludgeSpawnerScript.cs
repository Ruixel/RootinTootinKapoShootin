using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SludgeSpawnerScript : MonoBehaviour
{
    float timeBetweenSpawn = 30f;
    float timeSinceSpawn = 0f;
    int numberToSpawn = 20;


    public GameObject sludgeEnemyPrefab;
    public GameObject player;

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
            for (int i = 0; i < numberToSpawn; i++)
            {
                GameObject sludgeEnemy = Instantiate(sludgeEnemyPrefab, transform.position, Quaternion.identity);
                sludgeEnemy.GetComponent<SludgeEnemyController>().player = player;
            }
        }
    }
}
