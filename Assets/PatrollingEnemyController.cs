using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemyController : MonoBehaviour
{

    float speed = 3;

    float patrolTime = 3f;
    float currentPatrolTime = 0f;

    float xInput;

    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        xInput = speed * Time.deltaTime;
        currentPatrolTime = Random.Range(-1f, 4f);
        patrolTime = Random.Range(1f, 8f);
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

}
