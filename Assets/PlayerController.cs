using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    float speed = 5;

    float normalSpeed = 5;
    float dashSpeed;

    float xInput;
    float yInput;

    public float dashTime = 0.3f;
    float currentDashTime = 0;
    public float timeBetweenDash = 2f;
    float timeSinceDash = 0f;
    public float jumpSpeed;
    private bool isJumping;


    int numberOfBullets = 1;

    float knockbackForce = 30;

    public UnityAction<float> onDash;

//<<<<<<< Updated upstream

    public GameObject bulletPrefab;

//=======
    private Rigidbody2D rigidbody2d;
    private TrailRenderer trail;
    private Transform m_gunJoint;
    private SpriteRenderer m_spriteRenderer;
    
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
        m_gunJoint = transform.Find("GunJoint");
        m_spriteRenderer = GetComponent<SpriteRenderer>();
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
                for (int i = 1; i < numberOfBullets; i++)
                {
                    float randomYPos = Random.Range(0f, 1f);
                    float randomXPos = Random.Range(-1f, 1f);
                    Instantiate(bulletPrefab, transform.position + new Vector3(randomXPos, randomYPos, 0), Quaternion.identity);
                }
            }
        }

        // dash code
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > timeSinceDash)
        {
            timeSinceDash = timeBetweenDash + Time.time;
            trail.emitting = true;
            currentDashTime = dashTime;
            gameObject.layer = 8;

            if (onDash != null)
            {
                onDash.Invoke(timeBetweenDash);
            }
        }
        if (currentDashTime > 0)
        {
            currentDashTime = currentDashTime - Time.deltaTime;
            speed = dashSpeed;
            yInput = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        }
        else
        {
            trail.emitting = false;
            speed = normalSpeed;
            gameObject.layer = 0;
            yInput = 0;
        }

        // movement code
        xInput = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        transform.Translate(xInput, yInput, 0);

        //jump code
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            float jumpVelocity = 15f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            isJumping = true;
        }

        float angle = Mathf.Rad2Deg * Mathf.Atan2(displacementFromMouse.y, displacementFromMouse.x);
        m_gunJoint.rotation = Quaternion.Euler(0, 0, angle);

        Debug.Log(Mathf.Rad2Deg * angle);

        if (angle + 90 > 0 && angle + 90 < 180)
        {
            m_spriteRenderer.flipX = false;
        } else
        {
            m_spriteRenderer.flipX = true;
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
        

        if (other.gameObject.CompareTag("Wall"))
        {

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

}








