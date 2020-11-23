using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject disableButtonRight;
    [SerializeField]
    private GameObject disableButtonLeft;
    [SerializeField]
    private GameObject disableOfficeMenu;

    [SerializeField]
    private Transform[] movementPoints;
    [SerializeField]
    private float movSpeed;
    private float saveMovSpeed; // Save the currently set move speed (so you just have to use 'movSpeed = saveMovSpeed', instead of 'movSpeed = (value)', it just makes things easier

    [SerializeField]
    private Transform[] rotationPoints;
    [SerializeField]
    private float rotSpeed;


    private Rigidbody rigbody;


    private int selectedMovPoint;
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


        // If the camera is rotating towards a rotation point, and if isMoving is set to false, then...
        if (transform.rotation == rotationTargetRotation && isMoving == false)
        {
            //Debug.Log("This is being accessed!!!!!!!!!!!!");

            // Movement Point 0
            if (transform.position == movementPoints[0].position)// && transform.rotation == rotationTargetRotation && isMoving == false)
            {
                disableButtonRight.SetActive(true);

                disableOfficeMenu.SetActive(true);
            }


            // Movement Point 1
            if (transform.position == movementPoints[1].position)// && transform.rotation == rotationTargetRotation && isMoving == false)
            {
                disableButtonRight.SetActive(true);
                disableButtonLeft.SetActive(true);
            }


            // Movement Point 2
            if (transform.position == movementPoints[2].position)//  && transform.rotation == rotationTargetRotation && isMoving == false)
            {
                disableButtonRight.SetActive(true);
                disableButtonLeft.SetActive(true);
            }


            // Movement Point 3
            if (transform.position == movementPoints[3].position)//  && transform.rotation == rotationTargetRotation && isMoving == false)
            {
                disableButtonRight.SetActive(true);
                disableButtonLeft.SetActive(true);
            }


            // Movement Point 4
            if (transform.position == movementPoints[4].position)//  && transform.rotation == rotationTargetRotation && isMoving == false)
            {
                disableButtonRight.SetActive(true);
                disableButtonLeft.SetActive(true);
            }


            // Movement Point 5
            if (transform.position == movementPoints[5].position)//  && transform.rotation == rotationTargetRotation && isMoving == false)
            {
                disableButtonLeft.SetActive(true);
                disableButtonRight.SetActive(true);
            }


            // Movement Point 6
            if (transform.position == movementPoints[6].position)//  && transform.rotation == rotationTargetRotation && isMoving == false)
            {
                disableButtonLeft.SetActive(true);
            }
        }
        
        
        if (transform.position == movementPoints[0].position && transform.rotation != rotationTargetRotation && isMoving == true)
        {
            disableOfficeMenu.SetActive(false);
        }


        if (transform.position != movementPoints[selectedMovPoint].position)
        {
            disableButtonRight.SetActive(false);
            disableButtonLeft.SetActive(false);
        }

        //// If the camera position is equal to the movement point position, and if the camera is rotating towards a rotation point, and if isMoving is set to false, then...
        //// Movement Point 0
        //if (transform.position == movementPoints[0].position && transform.rotation == rotationTargetRotation && isMoving == false)
        //{
        //    Debug.Log("This is working!");

        //    disableButtonRight.SetActive(true);

        //    disableOfficeMenu.SetActive(true);
        //}
        //else if (transform.position != movementPoints[0].position && transform.rotation != rotationTargetRotation && isMoving == true)
        //{
        //    Debug.Log("This is NOT working!");

        //    disableOfficeMenu.SetActive(false);
        //}


        //// Movement Point 1
        //if (transform.position == movementPoints[1].position && transform.rotation == rotationTargetRotation && isMoving == false)
        //{
        //    disableButtonRight.SetActive(true);
        //    disableButtonLeft.SetActive(true);
        //}


        //// Movement Point 2
        //if (transform.position == movementPoints[2].position && transform.rotation == rotationTargetRotation && isMoving == false)
        //{
        //    disableButtonRight.SetActive(true);
        //    disableButtonLeft.SetActive(true);
        //}


        //// Movement Point 3
        //if (transform.position == movementPoints[3].position && transform.rotation == rotationTargetRotation && isMoving == false)
        //{
        //    disableButtonRight.SetActive(true);
        //    disableButtonLeft.SetActive(true);
        //}


        //// Movement Point 4
        //if (transform.position == movementPoints[4].position && transform.rotation == rotationTargetRotation && isMoving == false)
        //{
        //    disableButtonRight.SetActive(true);
        //    disableButtonLeft.SetActive(true);
        //}


        //// Movement Point 5
        //if (transform.position == movementPoints[5].position && transform.rotation == rotationTargetRotation && isMoving == false)
        //{
        //    disableButtonLeft.SetActive(true);
        //    disableButtonRight.SetActive(true);
        //}


        //// Movement Point 6
        //if (transform.position == movementPoints[6].position && transform.rotation == rotationTargetRotation && isMoving == false)
        //{
        //    disableButtonLeft.SetActive(true);
        //}



        //Debug.Log(selectedMovPoint);
        Debug.Log(selectedRotPoint);
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
        // Move until you reach the current object/waypoint, and then stop moving
        if (transform.position != movementPoints[selectedMovPoint].position)
        {
            // Wait until camera has rotated to face the direction of the next point before moving
            if (transform.rotation == rotationTargetMove)
            {
                movSpeed = saveMovSpeed;

                Vector3 pos = Vector3.MoveTowards(transform.position, movementPoints[selectedMovPoint].position, movSpeed * Time.deltaTime);
                rigbody.MovePosition(pos);
            }
        }
        else
        {
            isMoving = false;

            movSpeed = 0f;   
        }

    }


    // Buttons
    public void PressRight()
    {
        selectedMovPoint = (selectedMovPoint + 1) % movementPoints.Length;
        //selectedRotPoint = (selectedRotPoint + 1) % rotationPoints.Length;

        isMoving = true;

        
    }

    public void PressLeft()
    {
        selectedMovPoint = (selectedMovPoint - 1) % movementPoints.Length;
        //selectedRotPoint = (selectedRotPoint - 1) % rotationPoints.Length;

        isMoving = true;

        
    }
}
