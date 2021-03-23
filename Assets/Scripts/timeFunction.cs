using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeFunction : MonoBehaviour
{
    // Initialising ints and making the clock attachable inside Unity
    public int hour = 22;
    public int minute = 30;
    [SerializeField]
    private Text clock;

    // creating an unseen timer and couroutine inside script
    private float timer = 0;

    public static timeFunction abc;

    void Start()
    {
        StartCoroutine(incremental());
        Animation clkAnim = clock.GetComponent<Animation>();
    }

    // Enum stays true all the time so that we can count seconds instead of using ++
    // Waits one second, then follows with the IncrementTimer method
    IEnumerator incremental()
    {
        while (true)
        {
            //Wait for 1 second
            yield return new WaitForSeconds(1);

            //Increment
            incrementTimer();
        }
    }

    // IncrementTimer becomes active, adds 1 to the timer
    void incrementTimer()
    {
        timer += 1;
    }


    // if Timer reaches X seconds, then it will follow a series of rules
    // all the rules follow the way a digital clock works
    void Update()
    {
        if (timer == 1)
        {
            minute += 5;
            timer = 0;
            if (minute > 55)
            {
                hour += 1;
                minute = 0;
                timer = 0;
                if (hour > 23)
                {
                    hour = 0;
                    minute = 0;
                    timer = 0;
                }
            }
        }
        // Making it so only a UI Text can be attached
        Text clk = clock.GetComponent<Text>();
        // Constantly updating time and setting the ToString to "00" so that 0's can show up in front of numbers
        clk.text = (hour.ToString("00") + ":" + minute.ToString("00"));
    }
}
