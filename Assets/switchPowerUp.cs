using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchPowerUp : MonoBehaviour
{
    [SerializeField]
    private string soundOnCollision;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player"){
            Destroy(gameObject);
            AudioManager.PlaySound(soundOnCollision);
            KillAllEnemies();
        }

    }
    public void KillAllEnemies()
    {
        foreach (GameObject foe in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(foe);
        }
    }
}

