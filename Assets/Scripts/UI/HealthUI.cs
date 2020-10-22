using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    Health m_playerHealth;
    Image img;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController player = GameObject.FindObjectOfType<PlayerController>();
        m_playerHealth = player.GetComponent<Health>();

        img = GetComponent<Image>();

        if (m_playerHealth == null)
        {
            Debug.LogError("Player's health not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        img.fillAmount = m_playerHealth.currentHealth / m_playerHealth.maxHealth;
    }
}
