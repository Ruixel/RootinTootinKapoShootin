using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{

    [SerializeField]
    private int patrolEnemyHealth = 10;
    [SerializeField]
    private int patrolEnemyDamagedFromBullet = 1;
    private UnityEngine.Object explosionRef;
    // Start is called before the first frame update
    void Start()
    {
        explosionRef = Resources.Load("Explosion");

    }

    // Update is called once per frame

        private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Bullet")
        {
            patrolEnemyHealth -= patrolEnemyDamagedFromBullet;
            if (patrolEnemyHealth <=0){
                killTheBeast();
            }
        }
    }

    private void killTheBeast()
    {
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        Destroy(gameObject);
    }
}
