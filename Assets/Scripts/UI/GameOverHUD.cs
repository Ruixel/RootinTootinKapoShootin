using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverHUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerController player = GameObject.FindObjectOfType<PlayerController>();
        Health playerHealth = player.GetComponent<Health>();
        playerHealth.onDeath += OnDeath;
    }

    void OnDeath()
    {
        enabled = true;
    }
}
