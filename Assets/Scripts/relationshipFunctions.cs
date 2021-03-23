using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class relationshipFunctions : MonoBehaviour
{
    // Serializing the sliders inside of Unity
    [SerializeField]
    private Slider GoodMeter;
    [SerializeField]
    private Slider BadMeter;
    // Serializing the sliders Text components inside of Unity (tracks the slider value)
    [SerializeField]
    private TextMeshProUGUI GoodMeterNum;
    [SerializeField]
    private TextMeshProUGUI BadMeterNum;

    // Creating a float so that the number can be tracked inside the script
    public float GoodMeterFlo = 0;
    public float BadMeterFlo = 0;

    // enum created to give designers an easier time game designing
    public choiceEnum ChoiceOutcome = new choiceEnum();

    public animationChoices AnimationNeeded = new animationChoices();

    public enum choiceEnum
    {
        VeryGood,
        Good,
        VeryBad,
        Bad,
        None
    }

    public enum animationChoices
    {
        PleaseChooseAnOption, 
        Happy, 
        Sad, 
        Confused, 
        Angry, 
        Tired, 
        Scared, 
        NoAnimation
    }

    void Start()
    {
        // Script floats will always equal the slider value inside of Unity
        GoodMeterFlo = GoodMeter.value;
        BadMeterFlo = BadMeter.value;

        // The slider value inside unity will always equal to a float inside of another script (SceneMemory)
        // This is so values are remembered from scene to scene
        GoodMeter.value = SceneMemory.Instance.GoodMeterNumber;
        BadMeter.value = SceneMemory.Instance.BadMeterNumber;
    }

    public void MeterChanges()
    {
        // Collection of if statements stating which each of the choice enums will process
        if (ChoiceOutcome == choiceEnum.VeryGood)
        {
            GoodMeterFlo += 2;
            Debug.Log("Recognising 'Very Good' Setting");
        }

        else if (ChoiceOutcome == choiceEnum.Good)
        {
            GoodMeterFlo += 1;
            Debug.Log("Recognising 'Good' Setting");
        }

        if (ChoiceOutcome == choiceEnum.VeryBad)
        {
            BadMeterFlo += 2;
            Debug.Log("Recognising 'Very Bad' Setting");
        }

        else if (ChoiceOutcome == choiceEnum.Bad)
        {
            BadMeterFlo += 1;
            Debug.Log("Recognising 'Bad' Setting");
        }

        // Choice Enum being set to None after If statements are done
        // This makes it so the number added to the meters is not looped through
        ChoiceOutcome = choiceEnum.None;

        // Current slider value set to change the script float depending which option is chosen
        GoodMeter.value = GoodMeterFlo;
        BadMeter.value = BadMeterFlo;

        // SceneMemory float equaliing to the script float that was set above
        SceneMemory.Instance.GoodMeterNumber = GoodMeterFlo;
        SceneMemory.Instance.BadMeterNumber = BadMeterFlo;

        // The slider number changing to equal to the slider value found on the top left of the screen
        GoodMeterNum.text = GoodMeter.value.ToString();
        BadMeterNum.text = BadMeter.value.ToString();
    }

    void Update()
    {
        // This keeps the number on screen when changing scenes
        // Without this the numbers shown are '0', even though the actual values are remembered
        GoodMeterNum.text = GoodMeter.value.ToString();
        BadMeterNum.text = BadMeter.value.ToString();
    }
}