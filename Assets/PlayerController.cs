﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float speed = 5;

    float normalSpeed = 5;
    float dashSpeed = 25;

    float dashTime = 0.3f;
    float currentDashTime = 0;

//<<<<<<< Updated upstream

    public GameObject bullet;

//=======
    private Rigidbody2D rigidbody2d;
    
//>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {

        rigidbody2d = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        speed = 5;


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentDashTime = dashTime;
        }

        if (currentDashTime > 0)
        {
            currentDashTime = currentDashTime - Time.deltaTime;
            speed = dashSpeed;
        }
        else
        {
            speed = normalSpeed;
        }



        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet);
        }

        float xInput = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;

        transform.Translate(xInput, 0, 0);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 10f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            
        }


        void OnCollisionEnter (Collision collisionInfo)
        { if (collisionInfo.collider.tag == "floor")
            { 
                Debug.Log("ground");
            }
        }

    }
}








