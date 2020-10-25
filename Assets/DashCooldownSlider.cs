using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCooldownSlider : MonoBehaviour
{
    public Image m_sliderImage;

    PlayerController m_player;
    private float cooldown = 0f;
    private float maxDashTimer;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindObjectOfType<PlayerController>();
        m_player.onDash += activateDashCooldown;

        m_sliderImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
            cooldown = Mathf.Clamp(cooldown, 0f, cooldown);
        }

        m_sliderImage.fillAmount = cooldown / maxDashTimer;
    }

    void activateDashCooldown(float cooldownTime)
    {
        maxDashTimer = cooldownTime;
        cooldown = cooldownTime;
    }
}
