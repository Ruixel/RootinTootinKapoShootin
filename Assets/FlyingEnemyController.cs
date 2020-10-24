using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{

    public GameObject player;
    float speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 displacementFromTarget = player.transform.position - transform.position;
        Vector3 directionToTarget = displacementFromTarget.normalized;
        Vector3 velocity = directionToTarget * speed * Time.deltaTime;

        transform.Translate(velocity);
    }

}
