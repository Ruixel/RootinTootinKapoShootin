using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float speed = 5;

    float normalSpeed = 5;
    float dashSpeed = 25;

    float dashTime = 0.3f;
    float currentDashTime = 0;


    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {

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

    }

}
