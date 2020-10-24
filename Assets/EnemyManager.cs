using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    List<GameObject> enemies;

    public UnityAction<GameObject> onEnemyDeath;
    public UnityAction<GameObject> onEnemySpawn;

    public void Start()
    {
        onEnemyDeath += test;
    }

    public void enemySpawn(GameObject enemy)
    {
        Debug.Log("NEW ENEMY");
        if (onEnemySpawn != null)
        {
            onEnemySpawn.Invoke(enemy);
        }
    }
   
    void test(GameObject t)
    {
        Debug.Log("Help me");
    }
}
