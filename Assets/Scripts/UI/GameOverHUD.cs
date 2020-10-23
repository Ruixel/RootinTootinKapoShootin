using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverHUD : MonoBehaviour
{
    public GameObject gameOverFrame; 

    // Start is called before the first frame update
    void Start()
    {
        gameOverFrame.SetActive(false);

        PlayerController player = GameObject.FindObjectOfType<PlayerController>();
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth == null)
        {
            Debug.LogWarning("No Player Health");
        }

        playerHealth.onDeath += OnDeath;
    }

    void OnDeath()
    {
        Debug.Log("Sup");
        gameOverFrame.SetActive(true);
    }
}
