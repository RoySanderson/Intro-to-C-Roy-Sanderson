using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector] public int maxHealth = 100;
    [HideInInspector] public int currentHealth;
    public HealthBarScript healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.MaxHealth(maxHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SmallBullet"))
        {
            TakeDamage(20);
        }
        if (collision.gameObject.CompareTag("Health"))
        {
            GainHealth(60);
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void GainHealth(int extraHealth)
    {
        currentHealth += extraHealth;
        healthBar.SetHealth(currentHealth);
    }
}
