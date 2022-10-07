using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnTimer : MonoBehaviour
{
    public float turnTime;
    public float currentTime;
    [SerializeField] private TextMeshProUGUI timeText;

    public void Start()
    {
        currentTime = turnTime; 
    }

    public void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timeText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;

            if (currentTime == 0)
            {
                TurnManager.GetInstance().ChangeTurn();
                
            }
        }
    }
}
