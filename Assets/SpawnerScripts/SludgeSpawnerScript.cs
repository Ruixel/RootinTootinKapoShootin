using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SludgeSpawnerScript : MonoBehaviour
{

    float initialTimeBetweenSpawn = 40f;
    float timeBetweenSpawn = 40f;
    float timeSinceSpawn = 0f;

    int initialNumberToSpawn = 10;
    int numberToSpawn = 10;

    float difficultyModifier = 30;
    float spawningDifficultyModifier = 10;

    public GameObject sludgeEnemyPrefab;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timeBetweenSpawn > 7f)
        {
            timeBetweenSpawn = initialTimeBetweenSpawn - (Time.time / difficultyModifier);
            numberToSpawn = initialNumberToSpawn + Mathf.RoundToInt((Time.time / spawningDifficultyModifier));
        }


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
