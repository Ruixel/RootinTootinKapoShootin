using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyHP : MonoBehaviour
{

    [SerializeField]
    private int enemyHealth = 10;
    [SerializeField]
    private int enemyDamageFromBullet = 1;
    

        private UnityEngine.Object explosionRef;
    // Start is called before the first frame update
    void Start()
    {
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
            else{
                SoundManager.PlaySound("hitpatrol");
            }
        }
    }

    private void killTheBeast()
    {
        SoundManager.PlaySound("explode");
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        Destroy(gameObject);
    }
}
