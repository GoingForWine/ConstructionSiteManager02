using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class relationshipFunctions : MonoBehaviour
{
    [SerializeField]
    private Slider GoodMeter;
    [SerializeField]
    private Slider BadMeter;
    [SerializeField]
    private TextMeshProUGUI GoodMeterNum;
    [SerializeField]
    private TextMeshProUGUI BadMeterNum;

    public choiceEnum ChoiceOutcome = new choiceEnum();

    public enum choiceEnum
    {
        VeryGood,
        Good,
        VeryBad,
        Bad,
        None
    }

    public void MeterChanges()
    {
        if (ChoiceOutcome == choiceEnum.VeryGood)
        {
            GoodMeter.value += 2;
            Debug.Log("Recognising 'Very Good' Setting");
            ChoiceOutcome = choiceEnum.None;
        }

        if (ChoiceOutcome == choiceEnum.Good)
        {
            GoodMeter.value += 1;
            Debug.Log("Recognising 'Good' Setting");
            ChoiceOutcome = choiceEnum.None;
        }

        if (ChoiceOutcome == choiceEnum.VeryBad)
        {
            BadMeter.value += 2;
            Debug.Log("Recognising 'Very Bad' Setting");
            ChoiceOutcome = choiceEnum.None;
        }

        if (ChoiceOutcome == choiceEnum.Bad)
        {
            BadMeter.value += 1;
            Debug.Log("Recognising 'Bad' Setting");
            ChoiceOutcome = choiceEnum.None;
        }

        GoodMeterNum.text = GoodMeter.value.ToString();
        BadMeterNum.text = BadMeter.value.ToString();
    }
}