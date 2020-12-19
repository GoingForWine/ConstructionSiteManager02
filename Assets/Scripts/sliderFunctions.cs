using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class sliderFunctions : MonoBehaviour
{
    // Getting the slider from Unity and making it seen inside script
    public Slider slider;
    public TextMeshProUGUI sliderNum;

    // Setting colors for the slider fill to change to
    Color colorR = Color.red;
    Color colorY = Color.yellow;
    Color colorG = Color.green;

    // Slider add and negative numbers put into bool form
    public bool plus50 = false;
    public bool nega50 = false;
    public bool plus10 = false;
    public bool nega10 = false;

    [SerializeField]
    private int score;

    void Start()
    {
        // Taking slider from Unity and linking it to code
        slider = GetComponent<Slider>();

        //sliderNum = GetComponent<TextMeshProUGUI>();
        
    }

    void Update()
    {
        // Code constantly checking slider value, if slider value equals to any if statement, color changes
        if (slider.value >= 0 && slider.value <= 30)
        {
            slider.image.color = colorR;
        }
        if (slider.value >= 31 && slider.value <= 60)
        {
            slider.image.color = colorY;
        }
        if (slider.value >= 61 && slider.value <= 100)
        {
            slider.image.color = colorG;
        }

        // Telling game what to do when bool functions become active from button press
        if (plus50 == true)
        {
            score += 50;
            slider.value += 50;
            plus50 = false;
        }
        if (nega50 == true)
        {
            score -= 50;
            slider.value -= 50;
            nega50 = false;
        }
        if (plus10 == true)
        {
            score += 10;
            slider.value += 10;
            plus10 = false;
        }
        if (nega10 == true)
        {
            score -= 10;
            slider.value -= 10;
            nega10 = false;
        }



        // Make sure that the score value never goes above 100
        if(score >= 100)
        {
            score = 100;
        }
        else if (score <= 0)
        {
            score = 0;
        }

        sliderNum.text = score.ToString();
    }

    // Making the functions visible inside of Unitys 'On Click' screen, and telling them to make the bool true
    public void Add50()
    {
        plus50 = true;
    }
    public void Negative50()
    {
        nega50 = true;
    }
    public void Add10()
    {
        plus10 = true;
    }
    public void Negative10()
    {
        nega10 = true;
    }
}
