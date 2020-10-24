using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StatsUI : MonoBehaviour
{
    EnemyManager m_EnemyManager;

    public GameObject m_enemyNumberLabel;
    private Text m_enemyNumberTextComponent;

    private int enemyDeathCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_EnemyManager = GameObject.FindObjectOfType<EnemyManager>();
        if (m_EnemyManager == null)
        {
            Debug.LogError("No Enemy Manager Found");
        }
        m_EnemyManager.onEnemyDeath += incrementDeathCounter;

        m_enemyNumberTextComponent = m_enemyNumberLabel.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void incrementDeathCounter(GameObject enemy)
    {
        Debug.Log("Hello world");

        enemyDeathCount += 1;
        m_enemyNumberTextComponent.text = enemyDeathCount.ToString();
    }
}
