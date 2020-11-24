using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animationFunctions : MonoBehaviour
{
    // Serializing Fields to show in the Script tab inside Unity
    [SerializeField]
    private Animator animController;
    [SerializeField]
    private Button responseButton1;
    [SerializeField]
    private Button responseButton2;
    [SerializeField]
    private Button responseButton3;

    void Start()
    {
        // Setting the fields to only take in certain assets inside of unity, and respond to their functions
        animController = GetComponent<Animator>();
        Button btn1 = responseButton1.GetComponent<Button>();
        Button btn2 = responseButton2.GetComponent<Button>();
        Button btn3 = responseButton3.GetComponent<Button>();
        // Giving each button a method to run when pressed, switching a bool from to true to false
        btn1.onClick.AddListener(responseText1);
        btn2.onClick.AddListener(responseText2);
        btn3.onClick.AddListener(responseText3);
    }

    // Setting the bools inside the Animation Controller parameter to change to 'true' depending on which button has been pressed
    void responseText1()
    {
        animController.SetBool("Response1Bool", true);
    }

    void responseText2()
    {
        animController.SetBool("Response2Bool", true);
    }

    void responseText3()
    {
        animController.SetBool("Response3Bool", true);
    }
}
