using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemySpawnerScript : MonoBehaviour
{
    float timeBetweenSpawn = 4f;
    float timeSinceSpawn = 4f;

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
        if (Time.time > timeSinceSpawn)
        {
            timeSinceSpawn = Time.time + timeBetweenSpawn;
            GameObject patrollingEnemy = Instantiate(patrollingEnemyPrefab, transform.position, Quaternion.identity);

            m_EnemyManager.enemySpawn(patrollingEnemy);
        }
    }
}
