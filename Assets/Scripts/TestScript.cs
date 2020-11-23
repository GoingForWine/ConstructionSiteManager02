using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public Animator anim;
    public Button responseButton1;
    public Button responseButton2;
    public Button responseButton3;
    void Start()
    {
        anim = GetComponent<Animator>();
        Button btn1 = responseButton1.GetComponent<Button>();
        Button btn2 = responseButton2.GetComponent<Button>();
        Button btn3 = responseButton3.GetComponent<Button>();
        btn1.onClick.AddListener(responseText1);
        btn2.onClick.AddListener(responseText2);
        btn3.onClick.AddListener(responseText3);
    }

    void responseText1()
    {
        anim.SetBool("Response1Bool", true);
        Debug.Log("Clicked response 1");
    }

    void responseText2()
    {
        anim.SetBool("Response2Bool", true);
        Debug.Log("Clicked response 2");
    }

    void responseText3()
    {
        anim.SetBool("Response3Bool", true);
        Debug.Log("Clicked response 3");
    }
}
