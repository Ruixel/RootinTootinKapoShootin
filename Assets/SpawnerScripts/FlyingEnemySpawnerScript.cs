using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemySpawnerScript : MonoBehaviour
{
    float initialTimeBetweenSpawn = 10f;
    float timeBetweenSpawn = 10f;
    float timeSinceSpawn = 2f;

    public GameObject flyingEnemyPrefab;
    public GameObject player;

    float difficultyModifier = 7f;

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

        if (timeBetweenSpawn > 1f)
        {
            timeBetweenSpawn = initialTimeBetweenSpawn - (Time.time / difficultyModifier);
        }
        
        if (Time.time > timeSinceSpawn) {
            timeSinceSpawn = Time.time + timeBetweenSpawn;
            GameObject flyingEnemy = Instantiate(flyingEnemyPrefab, transform.position, Quaternion.identity);
            flyingEnemy.GetComponent<FlyingEnemyController>().player = player;

            m_EnemyManager.enemySpawn(flyingEnemy);
        }

    }
}
