using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static bool IsActive = true;
    private float timer = 0;
    public float StartTime = 0.0f;

    public Text TimerText;
    public static float TimerValue;

    private int total;
    private int minutes;
    private int seconds;

    // Start is called before the first frame update
    void Start()
    {
        TimerValue = StartTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive)
        {
            if(TimerValue > 0)
            {
                timer += Time.deltaTime;
                if (timer >= 1)
                {
                    TimerValue -= 1;
                    timer = 0;
                }
            }
            else
            {
                //MyGameManager.gameState = MyGameManager.GameStates.Gameover;
            }
        }

        total = (int)TimerValue;
        seconds = 0;
        minutes = 0;

        while(total >= 60)
        {
            total -= 60;
            minutes += 1;
        }
        seconds = total;

        TimerText.text = minutes.ToString() + ":";
        if(seconds <= 9)
        {
            TimerText.text += "0";
        }
        TimerText.text += seconds.ToString();
    }
}
