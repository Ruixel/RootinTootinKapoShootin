using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemyController : MonoBehaviour
{
    [SerializeField]
    private int patrolEnemyHealth = 10;
    [SerializeField]
    private int patrolEnemyDamagedFromBullet = 1;
    float speed = 1;

    float patrolTime = 1.5f;
    float currentPatrolTime = 0;

    float xInput;

    private UnityEngine.Object explosionRef;


    // Start is called before the first frame update
    void Start()
    {
        xInput = speed * Time.deltaTime;
        explosionRef = Resources.Load("Explosion");
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPatrolTime > 0)
        {
            currentPatrolTime = currentPatrolTime - Time.deltaTime;
        }
        else if (currentPatrolTime <= 0)
        {
            xInput  = xInput * -1;
            currentPatrolTime = patrolTime;
        }

        transform.Translate(xInput, 0, 0);
    }


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
