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
    public float jumpSpeed;
    private bool isJumping;

//<<<<<<< Updated upstream

    public GameObject bullet;

//=======
    private Rigidbody2D rigidbody2d;
    private TrailRenderer trail;
    
//>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        trail = transform.Find("Trail").GetComponent<TrailRenderer>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // bullet shoot code
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position + new Vector3(1.5f, 0, 0), transform.rotation);
        }

        // dash code
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            trail.emitting = true;
            currentDashTime = dashTime;
        }
        if (currentDashTime > 0)
        {
            currentDashTime = currentDashTime - Time.deltaTime;
            speed = dashSpeed;
        }
        else
        {
            trail.emitting = false;
            speed = normalSpeed;
        }

        // movement code
        float xInput = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        transform.Translate(xInput, 0, 0);
        //jump code

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            float jumpVelocity = 15f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            isJumping = true;
        }
    }
        void OnCollisionEnter2D(Collision2D other)

        {
            if (other.gameObject.CompareTag("floor"))
            {
                isJumping = false;
            }
        }
}








