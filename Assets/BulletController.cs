using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    float speed = 7;
    Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        moveDirection.z = 0f;
        moveDirection.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag != "Player" && collider.tag != "Bullet")
            Destroy(gameObject);
    }
}
