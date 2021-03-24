using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class InteractTimeFrame : MonoBehaviour
{
    // Serializing both the character specific box collider and notification inside of Unity
    [SerializeField]
    private BoxCollider characterBoxCollider;
    [SerializeField]
    private GameObject HeadNotification;

    // Creating a bool for if the Notification is active or not yet
    private bool NotifBool;

    //Referencing the current time inside the timeFunction script
    public timeFunction tf = new timeFunction();

    // Start & End Interact Window Times Editor in Unity
    [Header("Start Hour & Minute >> When The Window Starts")]
    [Header("v-- 24 hour clock system, please keep minutes to 5, 10, 15 etc. --v")]
    [Range(00, 23)]
    public int startHour = 0;
    [Range(00, 55)]
    public int startMinute = 0;
    [Header("End Hour & End Minute >> When The Window Ends")]
    [Range(00, 23)]
    public int endHour = 0;
    [Range(00, 55)]
    public int endMinute = 0;

    void InteractWindow()
    {
        // Setting what each bool rule follows
        // NOTE: I tried using else + else if, but it acted funny, so, sorry for the nooby coding here lmfao
        if (NotifBool == true)
        {
            HeadNotification.SetActive(true);
            characterBoxCollider.enabled = true;
        }
            
        if (NotifBool == false)
        {
            HeadNotification.SetActive(false);
            characterBoxCollider.enabled = false;
        }

        // If the referenced time from the timeFunction matches up with the Start hour & minute inside Unity, bool is switched to true
        if (startHour == tf.hour && startMinute == tf.minute)
        {
            NotifBool = true;  
        }
        // If the referenced time from the timeFunction matches up with the End hour & minute inside Unity, bool is switched to false
        else if (endHour == tf.hour && endMinute == tf.minute)
        {
            NotifBool = false;
        }
    }

    // Simply running the method and constantly updating, checking for changes
    void Update()
    {
        InteractWindow();
    }
}
