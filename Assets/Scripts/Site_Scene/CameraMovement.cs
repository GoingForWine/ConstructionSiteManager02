using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
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

    //private int desiredPoint; // This will be used another time
    private int selectedMovPoint;
    private int selectedRotPoint;


    private bool isMoving;

    // Rotation
    private Quaternion rotationTarget1;
    private Quaternion rotationTarget2;




    void Start()
    {
        rigbody = GetComponent<Rigidbody>();

        isMoving = true;

        saveMovSpeed = movSpeed;
    }


    // Update is called once per frame
    void Update()
    {
        selectedRotPoint = selectedMovPoint; // Automatically set the current rotation point number, to the current movement point number

        // When the camera reaches a certain movement point...
        //if (transform.position == movementPoints[0].position)
        //{

        //}
        //else if (transform.position == movementPoints[1].position)
        //{

        //}

        // Rotation (smooth rotation)

    }


    void FixedUpdate()
    {
        // Rotation (smooth rotation)
        if (isMoving == true && transform.position != movementPoints[selectedMovPoint].position)
        {
            rotationTarget1 = Quaternion.LookRotation(movementPoints[selectedMovPoint].position - transform.position); // Movement points
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationTarget1, rotSpeed * Time.deltaTime); // Rotate towards the movement points
        }
        else
        {
            rotationTarget2 = Quaternion.LookRotation(rotationPoints[selectedRotPoint].position - transform.position); // Rotation points
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationTarget2, rotSpeed * Time.deltaTime); // Rotate towards the rotation points
        }



        // Wait until camera has rotation in the direction of the next point before moving
        if (transform.rotation == rotationTarget1)
        {
            movSpeed = saveMovSpeed;

            // Move until you reach the current object/waypoint, and then stop moving
            if (transform.position != movementPoints[selectedMovPoint].position)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, movementPoints[selectedMovPoint].position, movSpeed * Time.deltaTime);
                rigbody.MovePosition(pos);
            }
            else
            {
                isMoving = false;

                movSpeed = 0;
            }
        }

    }


    // Buttons
    public void PressRight()
    {
        selectedMovPoint = (selectedMovPoint + 1) % movementPoints.Length;

        isMoving = true;
    }

    public void PressLeft()
    {
        selectedMovPoint = (selectedMovPoint - 1) % movementPoints.Length;

        isMoving = true;
    }
}
