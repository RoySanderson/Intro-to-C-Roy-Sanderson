using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider amountOfHealth;

    public void MaxHealth (int hp)
    {
        amountOfHealth.maxValue = hp;
        amountOfHealth.value = hp;
    }

    public void SetHealth(int health)
    {
        amountOfHealth.value = health; 
    }

   
}
