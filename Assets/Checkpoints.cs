using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Checkpoints : MonoBehaviour
{
    public PathCreator pathBig; 

    [SerializeField]
    public List<GameObject> checkpointsRotationTarget;

    [SerializeField]
    [Range (0,10000)]
    public int localPoint;

    private GameObject localPointIndicator;

    void Start()
    {
        localPointIndicator = new GameObject("TESTING LOCALPOINT TRANSFORM");
    }

    void Update()
    {
        localPointIndicator.transform.position =
        pathBig.path.localPoints[localPoint] + pathBig.gameObject.transform.position;

        //localPointIndicator.transform.position = 
    }

    //void AddCheckpoint()
    //{
    //    checkpoints.Add(new GameObject("Checkpoint" + checkpoints.Count));
    //}
}
