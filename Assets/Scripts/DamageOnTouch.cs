using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class DamageOnTouch : MonoBehaviour
{
    public Rigidbody2D enemyRigidBody { get; private set; }

    Collider2D m_collider;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        m_collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health player_hp = collision.gameObject.GetComponent<Health>();
            if (player_hp)
                player_hp.takeDamage(10f, this.gameObject);
        }
    }
}
