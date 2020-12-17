using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement_SmoothMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject disableButtonRight;
    [SerializeField]
    private GameObject disableButtonLeft;
    //[SerializeField]
    //private GameObject disableButtonUp;
    //[SerializeField]
    //private GameObject disableButtonDown;
    [SerializeField]
    private GameObject disableOfficeMenu;

    [SerializeField]
    private Transform[] movementPoints;
    [SerializeField]
    private Transform[] rotationPoints;


    [SerializeField]
    private float movSpeed;
    private float saveMovSpeed; // Save the currently set move speed (so you just have to use 'movSpeed = saveMovSpeed', instead of 'movSpeed = (value)', it just makes things easier
    [SerializeField]
    private float rotSpeed;


    private Rigidbody rigbody;

    [SerializeField]
    private int selectedMovPoint;
    [SerializeField]
    private int selectedRotPoint;


    private bool isMoving;
    //private bool isMovingRight;


    // Rotation
    private Quaternion rotationTargetMove;
    private Quaternion rotationTargetRotation;




    void Start()
    {
        rigbody = GetComponent<Rigidbody>();

        isMoving = false;

        saveMovSpeed = movSpeed;
    }


    // Update is called once per frame
    void Update()
    {
        selectedRotPoint = selectedMovPoint; // Automatically set the current rotation point number, to the current movement point number


        // Movement Point 0
        if (transform.position == movementPoints[0].position && isMoving == false)
        {
            disableButtonRight.SetActive(true);

            disableOfficeMenu.SetActive(true);
        }
        else if (transform.position != movementPoints[0].position || isMoving == true)
        {
            disableOfficeMenu.SetActive(false);
        }

        // Movement Point 1
        if (transform.position == movementPoints[1].position && isMoving == false)
        {
            disableButtonRight.SetActive(true);
            disableButtonLeft.SetActive(true);
        }


        //// Movement Point 2
        //if (transform.position == movementPoints[2].position)
        //{
        //    disableButtonRight.SetActive(true);
        //    disableButtonLeft.SetActive(true);
        //}


        //// Movement Point 3
        //if (transform.position == movementPoints[3].position)
        //{
        //    disableButtonRight.SetActive(true);
        //    disableButtonLeft.SetActive(true);
        //}


        //// Movement Point 4
        //if (transform.position == movementPoints[4].position)
        //{
        //    disableButtonRight.SetActive(true);
        //    disableButtonLeft.SetActive(true);
        //}


        //// Movement Point 5
        //if (transform.position == movementPoints[5].position)
        //{
        //    disableButtonLeft.SetActive(true);
        //}


        // Moving between points
        if (transform.position != movementPoints[selectedMovPoint].position || isMoving == true)
        {
            disableButtonRight.SetActive(false);
            disableButtonLeft.SetActive(false);
        }


        //Debug.Log(selectedMovPoint);
        //Debug.Log(selectedRotPoint);
        //Debug.Log(movSpeed); 
        //Debug.Log(isMoving);
    }


    void FixedUpdate()
    {
        Rotation();

        Movement();
    }


    private void Rotation()
    {
        // Rotation (smooth rotation)
        if (isMoving == true && transform.position != movementPoints[selectedMovPoint].position)
        {
            rotationTargetMove = Quaternion.LookRotation(movementPoints[selectedMovPoint].position - transform.position); // Movement points
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationTargetMove, rotSpeed * Time.deltaTime); // Rotate towards the movement points
        }
        else
        {
            rotationTargetRotation = Quaternion.LookRotation(rotationPoints[selectedRotPoint].position - transform.position); // Rotation points
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationTargetRotation, rotSpeed * Time.deltaTime); // Rotate towards the rotation points
        }
    }

    private void Movement()
    {
        if (transform.position != movementPoints[selectedMovPoint].position)
        {
            if (transform.rotation == rotationTargetMove)
            {
                movSpeed = saveMovSpeed;

                Vector3 pos = Vector3.MoveTowards(transform.position, movementPoints[selectedMovPoint].position, movSpeed * Time.deltaTime);
                rigbody.MovePosition(pos);
            }
        }
        else
        {
            movSpeed = 0f;

            if (transform.rotation == rotationTargetRotation)
            {
                isMoving = false;
            }
        }

    }


    // Buttons
    public void PressForward()
    {
        selectedMovPoint = (selectedMovPoint + 1) % movementPoints.Length;

        isMoving = true;

        // Disable buttons on HUD
        //disableButtonRight.SetActive(false);
        //disableButtonLeft.SetActive(false);
    }

    public void PressBackwards()
    {
        selectedMovPoint = (selectedMovPoint - 1) % movementPoints.Length;

        isMoving = true;

        // Disable buttons on HUD
        //disableButtonRight.SetActive(false);
        //disableButtonLeft.SetActive(false);
    }
}

