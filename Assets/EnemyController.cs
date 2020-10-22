using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    float speed = 1;

    float patrolTime = 1.5f;
    float currentPatrolTime = 0;

    float xInput;


    // Start is called before the first frame update
    void Start()
    {
        xInput = speed * Time.deltaTime;
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
