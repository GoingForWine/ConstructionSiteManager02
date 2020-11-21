using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform[] movementPoints;

    [SerializeField]
    private float movSpeed;
    [SerializeField]
    private float rotSpeed;


    private Rigidbody rigbody;

    //private int desiredPoint; // This will be used another time
    private int selectedPoint;

    private bool canMoveRight;

    private bool isAbleToMove; // This will be used properly later


    void Start()
    {
        rigbody = GetComponent<Rigidbody>();

        isAbleToMove = true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate()
    {
        // Rotation (smooth rotation)
        Quaternion rotationTarget = Quaternion.LookRotation(movementPoints[selectedPoint].position - this.transform.position);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotationTarget, rotSpeed * Time.deltaTime);
        


        // Determine whether the camera will move to the right or the left
        if (transform.position == movementPoints[0].position)
        {
            canMoveRight = true;
        }
        else if (transform.position == movementPoints[5].position)
        {
            canMoveRight = false;
        }



        // Wait until camera has rotation in the direction of the next point before moving
        if (this.transform.rotation == rotationTarget)
        {
            // Move until you reach the current object/waypoint
            if (transform.position != movementPoints[selectedPoint].position)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, movementPoints[selectedPoint].position, movSpeed * Time.deltaTime);
                rigbody.MovePosition(pos);
            }
        }

        // Once the camera has reached the current movement point, move to the next point
        if (transform.position == movementPoints[selectedPoint].position)
        {
            // Move camera backwards when it reaches the last point
            if (canMoveRight == true)
            {
                selectedPoint = (selectedPoint + 1) % movementPoints.Length;
            }
            else if (canMoveRight == false)
            {
                selectedPoint = (selectedPoint - 1) % movementPoints.Length;
            }
        }
    }
}
