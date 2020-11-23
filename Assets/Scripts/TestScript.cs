using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            anim.SetBool("IsBool", true);
            Debug.Log("hello");
        }
        else
            anim.SetBool("IsBool", false);
    }
}
