using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    private int activePlayerIndex;
    [SerializeField] private Camera camera1;
    [SerializeField] private Camera camera2;
    [SerializeField] private AudioListener audio1;
    [SerializeField] private AudioListener audio2;
    public TurnTimer timer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            activePlayerIndex = 1;
            camera1.enabled = true;
            camera2.enabled = false;
            audio1.enabled = true;
            audio2.enabled = false;
        }
        else
            Destroy(this.gameObject);
    }

    public bool PlayerIsActive(int index)
    {
        return index == activePlayerIndex;
    }

    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void ChangeTurn()
    {
        if(activePlayerIndex == 1)
        {
            timer.currentTime = timer.turnTime;
            activePlayerIndex = 2;
            camera2.enabled = true;
            camera1.enabled = false;
            audio2.enabled = true;
            audio1.enabled = false;
        }
        else if(activePlayerIndex == 2)
        {
            timer.currentTime = timer.turnTime;
            activePlayerIndex = 1;
            camera1.enabled= true;
            camera2.enabled = false;
            audio1.enabled = true;
            audio2.enabled = false;
        }
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            ChangeTurn();
        }

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.visible = true;
        }
        else
            Cursor.visible = false;
    }
}
