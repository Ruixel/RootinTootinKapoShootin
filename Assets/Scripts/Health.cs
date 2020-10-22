using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;

    public UnityAction<float, GameObject> onDamaged;
    public UnityAction onDeath;

    public float currentHealth { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(float damage, GameObject damageSource)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        if (currentHealth <= 0f)
        {
            onDeath.Invoke();
        }
    }
}
