using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class CameraMovement : MonoBehaviour
{
    public GameObject disableButtonRight;
    public GameObject disableButtonLeft;
    public GameObject disableOfficeMenu;

    [SerializeField]
    private Transform[] movementPoints;

    [SerializeField]
    private Transform[] startingRotationPoints;

    [SerializeField]
    private Transform[] endingRotationPoints;

    [SerializeField]
    private float rotSpeed;

    public sbyte selectedMovPoint;
    public sbyte selectedRotPoint;

    public bool isMoving;

    private Quaternion rotationTargetMove;
    private Quaternion rotationTargetRotation;

    public PathFollower x;
    bool rightDirection;
    private Quaternion rotationX;
    //x -0.03919389
    //y  0.7060199
    //z -0.03919391
    //w -0.7060195

    void Start()
    {
        isMoving = false;
        rotationX.x = -0.03919389f;
        rotationX.y = 0.7060199f;
        rotationX.z = -0.03919391f;
        rotationX.w = -0.7060195f;
    }

    void Update()
    {
        selectedRotPoint = selectedMovPoint; // Automatically set the current rotation point number, to the current movement point number

        DisableOfficeUI();
        DisableArrows();
        
        Rotation();
    }

    public void Rotation()
    {
        // Rotation (smooth rotation)
        if (isMoving)
        {
            if (selectedMovPoint == 7)
            {
                rotationTargetMove = Quaternion.LookRotation(startingRotationPoints[6].position - transform.position); // Movement points
            }
            else if (selectedMovPoint == 1 || selectedMovPoint == 0)
            {
                rotationTargetMove = Quaternion.LookRotation(startingRotationPoints[0].position - transform.position); // Movement points
            }
            else
            {
                if (rightDirection)       //if moving right or left -> rotate to the correct startingrotationpoint from the array
                {
                    rotationTargetMove = Quaternion.LookRotation(startingRotationPoints[selectedMovPoint - 1].position - transform.position); // Movement points
                }
                else
                {
                    rotationTargetMove = Quaternion.LookRotation(startingRotationPoints[selectedMovPoint].position - transform.position); // Movement points
                }
            }
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationTargetMove, rotSpeed * Time.deltaTime); // Rotate towards the movement points
        }
        else
        {
            GetComponent<PathFollower>().enabled = false;
            rotationTargetRotation = Quaternion.LookRotation(endingRotationPoints[selectedRotPoint].position - transform.position); // Rotation points
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationTargetRotation, rotSpeed * Time.deltaTime); // Rotate towards the rotation points
        }
    }

    void Movement()
    {
        GetComponent<PathFollower>().enabled = true;
        for (sbyte i = 0; i < movementPoints.Length; i++)
        {
            if (transform.position == movementPoints[i].position)
            {
                if (rightDirection)
                {
                    x.pathInMotion = x.paths[i * 2];
                }
                else
                {
                    x.pathInMotion = x.paths[i * 2 - 1];
                }
            }
        }
        x.distanceTravelled = 0;
    }

    // Buttons
    public void PressRight()
    {
        selectedMovPoint++;
        isMoving = true;
        rightDirection = true;

        GetComponent<PathFollower>().enabled = false;

        Invoke("Movement", 0.8f);
    }

    public void PressLeft()
    {
        selectedMovPoint--;
        isMoving = true;
        rightDirection = false;

        GetComponent<PathFollower>().enabled = false;

        Invoke("Movement", 0.8f);
    }

    void DisableOfficeUI()
    {
        ////disable officeMenu
        //if (transform.position != movementPoints[0].position 
        //    || transform.rotation != Quaternion.LookRotation(endingRotationPoints[0].position - transform.position)
        //    || transform.rotation != rotationX)
        //{
        //    print('s');
        //    disableOfficeMenu.SetActive(false);

        //    print("transform rotation" + transform.rotation);
        //    print("quartertion" + Quaternion.LookRotation(endingRotationPoints[0].position - transform.position));
        //    print(transform.rotation != Quaternion.LookRotation(endingRotationPoints[0].position - transform.position));
        //}
        //else
        //{
        //    print('l');
        //    disableOfficeMenu.SetActive(true);

        //    print("transform rotation" + transform.rotation);
        //    print("quartertion" + Quaternion.LookRotation(endingRotationPoints[0].position - transform.position));
        //    print(transform.rotation != Quaternion.LookRotation(endingRotationPoints[0].position - transform.position));
        //}

        //disable officeMenu
        if (transform.rotation == Quaternion.LookRotation(endingRotationPoints[0].position - transform.position) || transform.rotation == rotationX)
        {
            disableOfficeMenu.SetActive(true);
        }
        else
        {
            disableOfficeMenu.SetActive(false);
        }
    }

    void DisableArrows()
    {
        //disable and enable buttonsUI
        if (transform.position != movementPoints[selectedMovPoint].position)
        {
            disableButtonRight.SetActive(false);
            disableButtonLeft.SetActive(false);
        }
        else if (transform.position == movementPoints[0].position)
        {
            disableButtonRight.SetActive(true);
            disableButtonLeft.SetActive(false);
            isMoving = false;
        }
        else if (transform.position == movementPoints[6].position)
        {
            disableButtonRight.SetActive(false);
            disableButtonLeft.SetActive(true);
            isMoving = false;
        }
        else
        {
            disableButtonRight.SetActive(true);
            disableButtonLeft.SetActive(true);
            isMoving = false;
        }
    }
}