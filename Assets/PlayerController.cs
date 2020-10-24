using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float speed = 5;

    float normalSpeed = 5;
    float dashSpeed;

    float xInput;

    float dashTime = 0.3f;
    float currentDashTime = 0;
    public float jumpSpeed;
    private bool isJumping;

    int numberOfBullets = 1;

    float knockbackForce = 50;

//<<<<<<< Updated upstream

    public GameObject bulletPrefab;

//=======
    private Rigidbody2D rigidbody2d;
    private TrailRenderer trail;
    
//>>>>>>> Stashed changes

    // Unity Built In functions
    // Start is called before the first frame update
    void Start()
    {
        dashSpeed = normalSpeed * 5;
    }
    private void Awake()
    {
        trail = transform.Find("Trail").GetComponent<TrailRenderer>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 displacementFromMouse = cursorInWorldPos - transform.position;
        Vector3 directionToMouse = displacementFromMouse.normalized;


        // bullet shoot code
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            if (numberOfBullets > 1)
            {
                for (int i = 1; i < numberOfBullets; i++) {
                    Instantiate(bulletPrefab, transform.position + new Vector3(0, i, 0), Quaternion.identity);
                }
            }
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
        xInput = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;

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
        // should probably be a switch statement
        if (other.gameObject.CompareTag("floor"))
        {
            isJumping = false;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Vector3 displacementToOther = other.transform.position - transform.position;
            Vector3 directionToOther = displacementToOther.normalized;
            Vector2 directionToOther2D = new Vector2(directionToOther.x, directionToOther.y);
            rigidbody2d.AddForce(directionToOther2D * knockbackForce * -1, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "NumberOfBulletsPowerup")
        {
            numberOfBullets++;
            Destroy(collider.gameObject);
        }
    }

    // newly written functions
    void Dash()
    {

    }

    void Knockback()
    {

    }
}








