using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SludgeEnemyController : MonoBehaviour
{

    public GameObject player;

    float timeBetweenJumps = 1.5f;
    float timeSinceJump = 0f;

    float jumpHeight = 7f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Time.time > timeSinceJump) {

            timeSinceJump = Time.time + timeBetweenJumps;
            float randomMove = Random.Range(-5, 5);
            rb.AddForce(new Vector2(randomMove, jumpHeight), ForceMode2D.Impulse);
        }
    }
}
