using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{

    [SerializeField]
    private int enemyHealth = 10;
    [SerializeField]
    private int enemyDamageFromBullet = 1;
    [SerializeField]
    private string deathCry;

    [SerializeField]
    private string bulletImpact;

    

    private UnityEngine.Object explosionRef;
    EnemyManager m_EnemyManager;

    // Start is called before the first frame update
    void Start()
    {
        m_EnemyManager = GameObject.FindObjectOfType<EnemyManager>();
        explosionRef = Resources.Load("Explosion");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Bullet")
        {
            enemyHealth -= enemyDamageFromBullet;
            if (enemyHealth <=0){
                killTheBeast();
            }
            else {
                AudioManager.PlaySound(bulletImpact);
            }
        }
    }

    private void killTheBeast()
    {
        if (m_EnemyManager.onEnemyDeath != null)
        {
            m_EnemyManager.onEnemyDeath.Invoke(gameObject);
        }
        AudioManager.PlaySound(deathCry);
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        Destroy(gameObject);
    }
}
