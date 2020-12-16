using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeFunction : MonoBehaviour
{
    // Initialising ints and making the clock attachable inside Unity
    private int hour = 10;
    private int minute = 05;
    [SerializeField]
    private Text clock;

    private float timer = 0;
    private float secondIncrease;

    void Update()
    {
        timer += secondIncrease * Time.deltaTime;
        if (timer == 5)
        {
            hour += 1;
            timer = 0;
        }
        // Making it so only a UI Text can be attached
        Text clk = clock.GetComponent<Text>();
        // Constantly updating time and setting the ToString to "00" so that 0's can show up in front of numbers
        clk.text = (hour.ToString("00") + ":" + minute.ToString("00"));
    }
}
