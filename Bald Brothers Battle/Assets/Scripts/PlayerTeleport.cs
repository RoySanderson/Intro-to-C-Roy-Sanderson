using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public HealthBarScript healthBar;
    public float posX;
    public float posY;
    public float posZ;

    void Update()
    {
       if (playerHealth.currentHealth <= 0)
        {
            gameObject.transform.position = new Vector3(posX, posY, posZ);
            playerHealth.currentHealth = 100;
            healthBar.MaxHealth(100);
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("InvisFloor"))
        {
            gameObject.transform.position = new Vector3(posX, posY, posZ);
        }
    }
}
