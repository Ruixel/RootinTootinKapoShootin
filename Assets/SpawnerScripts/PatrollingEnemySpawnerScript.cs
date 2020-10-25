using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemySpawnerScript : MonoBehaviour
{

    float initialTimeBetweenSpawn = 10f;
    float timeBetweenSpawn = 10f;
    float timeSinceSpawn = 4f;

    float difficultyModifier = 10f;

    public GameObject patrollingEnemyPrefab;

    EnemyManager m_EnemyManager;
    // Start is called before the first frame update
    void Start()
    {
        m_EnemyManager = GameObject.FindObjectOfType<EnemyManager>();
        if (m_EnemyManager == null)
            Debug.LogError("Could not find enemy manager");
    }

    // Update is called once per frame
    void Update()
    {

        if (timeBetweenSpawn > 3f)
        {
            timeBetweenSpawn = initialTimeBetweenSpawn - (Time.time / difficultyModifier);
        }


        if (Time.time > timeSinceSpawn)
        {
            timeSinceSpawn = Time.time + timeBetweenSpawn;
            GameObject patrollingEnemy = Instantiate(patrollingEnemyPrefab, transform.position, Quaternion.identity);

            m_EnemyManager.enemySpawn(patrollingEnemy);
        }
    }
}
