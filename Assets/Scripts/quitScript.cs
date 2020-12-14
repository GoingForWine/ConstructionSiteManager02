using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quitScript : MonoBehaviour
{
    // Serializing Fields to show in the Script tab inside Unity
    [SerializeField]
    private Animator quitAnimController;
    [SerializeField]
    private Button laptopOpen;
    [SerializeField]
    private Button laptopQuit;

    void Start()
    {
        // Setting the fields to only take in certain assets inside of unity, and respond to their functions
        quitAnimController = GetComponent<Animator>();
        Button openButton = laptopOpen.GetComponent<Button>();
        Button quitButton = laptopQuit.GetComponent<Button>();
        // Giving each button a method to run when pressed, switching a bool from to true to false
        quitButton.onClick.AddListener(quit);
        openButton.onClick.AddListener(open);
    }

    // Setting the bools inside the Animation Controller parameter to change to 'true' depending on which button has been pressed
    void open()
    {
        quitAnimController.SetBool("openBool", true);
        quitAnimController.SetBool("quitBool", false);
    }
    void quit()
    {
        quitAnimController.SetBool("quitBool", true);
        quitAnimController.SetBool("openBool", false);
    }
}