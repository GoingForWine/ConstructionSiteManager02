using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;

/// <summary>
/// This script is still under development
/// </summary>

public class CameraMovement_BezierCurve : MonoBehaviour
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

    public PathCreator pathBig;
    public PathFollower x;


    bool rightDirection;
    private Quaternion rotationX;
    //x -0.03919389
    //y  0.7060199
    //z -0.03919391
    //w -0.7060195

    void Start()
    {
        //isMoving = false;
        //rotationX.x = -0.03919389f;
        //rotationX.y = 0.7060199f;
        //rotationX.z = -0.03919391f;
        //rotationX.w = -0.7060195f;
    }

    void Update()
    {
        //selectedRotPoint = selectedMovPoint; // Automatically set the current rotation point number, to the current movement point number


        DisableOfficeUI();
        DisableArrows();
        Rotation();
    }

    //here we are going to check if we have reached a checkpoint
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            Debug.Log(x.distanceTravelled + " -1");
            //stop
            x.forward = false;
            x.backward = false;
            x.stopMovement = true;

            //this.transform.position =  + this.transform.position;

            //HAVE TO REMAKE CHECKPOINTS TO BE NOT ON LOCAL POINTS BUT ON DISTANCETRAVELED. 

            //arrival!

            GameObject target = FindClosestWithTag("Checkpoint");
            //Vector3 distanceToTarget = this.transform.position - target.transform.position;
            //distanceToTarget.x = Mathf.Abs(distanceToTarget.x);
            //distanceToTarget.y = Mathf.Abs(distanceToTarget.y);
            //distanceToTarget.z = Mathf.Abs(distanceToTarget.z);

            float exactDistanceTravelledAtTarget = pathBig.path.GetClosestDistanceAlongPath(target.transform.position);

            //while (!distanceToTarget.Equals(new Vector3((float)0.1, (float)0.1, (float)0.1)))
            //{
            //    if (x.forward)
            //    {
            //        x.distanceTravelled += (x.speed + Time.deltaTime) * distanceToTarget.magnitude;
            //    }
            //    else if (x.backward)
            //    {
            //        x.distanceTravelled -= (x.speed + Time.deltaTime) * distanceToTarget.magnitude;
            //    }
            //}

            if (x.forward)
            {
                while (exactDistanceTravelledAtTarget > x.distanceTravelled + 0.1)
                {
                    x.distanceTravelled += (x.speed + Time.deltaTime) * (exactDistanceTravelledAtTarget - x.distanceTravelled);
                }
            }
            else if (x.backward)
            {
                while (exactDistanceTravelledAtTarget < x.distanceTravelled - 0.1)
                {
                    x.distanceTravelled -= (x.speed + Time.deltaTime) * (exactDistanceTravelledAtTarget + x.distanceTravelled);
                }
            }

            x.distanceTravelled = exactDistanceTravelledAtTarget;


            //rotate to target
            //podai rotation sus parametr kum targeta ni

            //vuv kopchetata moje bi shte e initial rotate-ta

            //enable arrows
            //disableButtonRight.SetActive(true);
            //disableButtonLeft.SetActive(true);
        }
    }

    private GameObject FindClosestWithTag(string tag)
    {
        float distanceToClosest = Mathf.Infinity;
        GameObject closestObject = null;
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag(tag);

        foreach (var currentObject in allObjects)
        {
            float distanceToObject = (currentObject.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToObject < distanceToClosest)
            {
                distanceToClosest = distanceToObject;
                closestObject = currentObject;
            }
        }

        //Debug.Log("Closest GameObject with Tag   \" " + tag + " \"   is - \" " + closestObject.name + " \" . ");

        return closestObject;
    }

    private int FindCurrentLocationPointIndex()
    {
        int currentPoint = 0;

        foreach (var point in pathBig.path.localPoints)
        {
            Debug.Log(currentPoint);

            currentPoint++;
            //looking for a local point.position == to the camera.position; 
            if (point.x == this.transform.position.x || point.y == this.transform.position.y || point.z == this.transform.position.z)
            {
                break;
            }
        }

        //Debug.Log("Current Location Point the Camera is on is " + pathBig.path.localPoints[currentPoint] + "at index " + currentPoint);

        return currentPoint;
    }

    public void Rotation()
    {
        #region h
        //// Rotation (smooth rotation)
        //if (isMoving)
        //{
        //    if (selectedMovPoint == 7)
        //    {
        //        rotationTargetMove = Quaternion.LookRotation(startingRotationPoints[6].position - transform.position); // Movement points
        //    }
        //    else if (selectedMovPoint == 1 || selectedMovPoint == 0)
        //    {
        //        rotationTargetMove = Quaternion.LookRotation(startingRotationPoints[0].position - transform.position); // Movement points
        //    }
        //    else
        //    {
        //        if (rightDirection)       //if moving right or left -> rotate to the correct startingrotationpoint from the array
        //        {
        //            rotationTargetMove = Quaternion.LookRotation(startingRotationPoints[selectedMovPoint - 1].position - transform.position); // Movement points
        //        }
        //        else
        //        {
        //            rotationTargetMove = Quaternion.LookRotation(startingRotationPoints[selectedMovPoint].position - transform.position); // Movement points
        //        }
        //    }
        //    transform.rotation 
        //       = Quaternion.RotateTowards(transform.rotation, rotationTargetMove, rotSpeed * Time.deltaTime); // Rotate towards the movement points
        //}
        //else
        //{
        //    //GetComponent<PathFollower>().enabled = false;
        //    rotationTargetRotation = Quaternion.LookRotation(endingRotationPoints[selectedRotPoint].position - transform.position); // Rotation points
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationTargetRotation, rotSpeed * Time.deltaTime); // Rotate towards the rotation points
        //}
        #endregion  
        if (x.stopMovement)
        {
            //this will check constantly for nearest interactable, so moving NPCanimation would work fine and refocus camera to the new object
            GameObject rotationTarget = FindClosestWithTag("Interactable");

            //rotate to closest intaractable
            transform.rotation =
               Quaternion.RotateTowards(transform.rotation,
               Quaternion.LookRotation(rotationTarget.transform.position - this.transform.position),
               rotSpeed * Time.deltaTime);

            //if  we have rotated towards the target 
            if (this.transform.rotation == Quaternion.LookRotation(rotationTarget.transform.position))
            {
                x.hasTurned = true;
            }
            else
            {
                x.hasTurned = false;
            }

        }
        else
        {
            //rotate to a location point from the path and then move    while rotation diff, rotate    then   forward or backward true; 
            if (!x.hasTurned)
            {
                Vector3 rotationTarget = Vector3.zero;

                if (x.forward)
                {
                    Debug.Log(FindCurrentLocationPointIndex());
                    rotationTarget = pathBig.path.localPoints[FindCurrentLocationPointIndex() + 1] + pathBig.gameObject.transform.position;
                }
                else if (x.backward)
                {
                    rotationTarget = pathBig.path.localPoints[FindCurrentLocationPointIndex() - 1] + pathBig.gameObject.transform.position;
                }

                transform.rotation =
                   Quaternion.RotateTowards(transform.rotation,
                   Quaternion.LookRotation(rotationTarget),
                   rotSpeed * Time.deltaTime);

                //if  we have rotated towards the target 
                if (this.transform.rotation == Quaternion.LookRotation(rotationTarget))
                {
                    x.hasTurned = true;
                }
                else
                {
                    x.hasTurned = false;
                }
            }
        }
    }

    void Movement()
    {
        GetComponent<PathFollower>().enabled = true;
        //for (sbyte i = 0; i < movementPoints.Length; i++)
        //{
        //    if (transform.position == movementPoints[i].position)
        //    {
        //        if (rightDirection)
        //        {
        //            x.pathInMotion = x.paths[i * 2];
        //        }
        //        else
        //        {
        //            x.pathInMotion = x.paths[i * 2 - 1];
        //        }
        //    }
        //}
        //x.distanceTravelled = 0;

    }

    // Buttons
    public void PressRight()
    {
        //selectedMovPoint++;
        //isMoving = true;
        //rightDirection = true;

        x.stopMovement = false;
        x.forward = true;

        //GetComponent<PathFollower>().enabled = false;

        //Invoke("Movement", 0.8f);
    }

    public void PressLeft()
    {
        //    selectedMovPoint--;
        //    isMoving = true;
        //    rightDirection = false;

        x.stopMovement = false;
        x.backward = true;

        //GetComponent<PathFollower>().enabled = false;

        //Invoke("Movement", 0.8f);
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

        ////disable and enable officeMenu
        //if (transform.rotation == Quaternion.LookRotation(endingRotationPoints[0].position - transform.position) || transform.rotation == rotationX)
        //{
        //    disableOfficeMenu.SetActive(true);

        //}
        //else
        //{
        //    disableOfficeMenu.SetActive(false);
        //}

        if (FindClosestWithTag("Interactable").name == "laptop screen" && x.stopMovement && FindClosestWithTag("Checkpoint").name == "OfficePoint")
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
        ////disable and enable buttonsUI
        //if (transform.position != movementPoints[selectedMovPoint].position)
        //{
        //    disableButtonRight.SetActive(false);
        //    disableButtonLeft.SetActive(false);
        //}
        //else if (transform.position == movementPoints[0].position)
        //{
        //    disableButtonRight.SetActive(true);
        //    disableButtonLeft.SetActive(false);
        //    isMoving = false;
        //}
        //else if (transform.position == movementPoints[6].position)
        //{
        //    disableButtonRight.SetActive(false);
        //    disableButtonLeft.SetActive(true);
        //    isMoving = false;
        //}
        //else
        //{
        //    disableButtonRight.SetActive(true);
        //    disableButtonLeft.SetActive(true);
        //    isMoving = false;
        //}

        if (x.forward || x.backward)
        {
            disableButtonRight.SetActive(false);
            disableButtonLeft.SetActive(false);
        }
        else
        {
            disableButtonRight.SetActive(true);
            disableButtonLeft.SetActive(true);
        }
    }
}
