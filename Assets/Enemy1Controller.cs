using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    [SerializeField]
    private int enemyHealth = 10;
    [SerializeField]
    private int enemyDamageFromBullet = 1;
    public GameObject player;

    float speed = 5;
    private UnityEngine.Object explosionRef;

    // Start is called before the first frame update
    void Start()
    {
        explosionRef = Resources.Load("Explosion");

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 displacementFromTarget = player.transform.position - transform.position;
        Vector3 directionToTarget = displacementFromTarget.normalized;
        Vector3 velocity = directionToTarget * speed * Time.deltaTime;

        transform.Translate(velocity);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Bullet")
        {
            enemyHealth -= enemyDamageFromBullet;
            if (enemyHealth <=0){
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
