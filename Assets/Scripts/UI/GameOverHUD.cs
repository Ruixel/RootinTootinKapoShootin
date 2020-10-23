using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHUD : MonoBehaviour
{
    public GameObject gameOverFrame;

    public Button m_tryAgainButton;
    public Button m_quitButton;

    private UnityAction m_tryAgainPressed;
    private UnityAction m_quitPressed;

    // Start is called before the first frame update
    void Start()
    {
        gameOverFrame.SetActive(false);

        m_tryAgainPressed += restartScene;
        m_quitPressed += quitGame;

        m_tryAgainButton.onClick.AddListener(m_tryAgainPressed);
        m_quitButton.onClick.AddListener(m_quitPressed);

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
        gameOverFrame.SetActive(true);
    }

    void restartScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
