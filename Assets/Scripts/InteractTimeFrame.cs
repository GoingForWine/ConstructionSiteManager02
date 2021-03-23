using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class InteractTimeFrame : MonoBehaviour
{
    [SerializeField]
    private BoxCollider characterBoxCollider;
    [SerializeField]
    private GameObject HeadNotification;

    public timeFunction tf = new timeFunction();

    [Range(0, 23)]
    public int hour2 = 0;
    [Range(0, 59)]
    public int minute2 = 0;

    public hourEnum startHour = new hourEnum();
    public minuteEnum startMinute = new minuteEnum();
    public hourEnum endHour = new hourEnum();
    public minuteEnum endMinute = new minuteEnum();

    public enum hourEnum
    {
        Zero = 0, One = 1, Two = 2, Three = 3, Four = 4,
        Five = 5, Six = 6, Seven = 7, Eight = 8,
        Nine = 9, Ten = 10, Eleven = 11, Twelve = 12, 
        Thirteen = 13, Fourteen = 14, Fifteen = 15, Sixteen = 16, 
        Seventeen = 17, Eighteen = 18, Nineteen = 19, Twenty = 20, 
        TwentyOne = 21, TwentyTwo = 22, TwentyThree = 23
    }

    public enum minuteEnum
    {
        Zero = 0, Five = 5, Ten = 10, Fifteen = 15,
        Twenty = 20, TwentyFive = 25, Thirty = 30, ThirtyFive = 35, 
        Forty = 40, FortyFive = 45, Fifty = 50, FiftyFive = 55
    }

    void Update()
    {
        if (startHour == hourEnum.TwentyThree && tf.hour == 23)
        {
            HeadNotification.SetActive(true);
        }   else
        {
            HeadNotification.SetActive(false);
        }

        //if (startHour == hour)
    }
}
