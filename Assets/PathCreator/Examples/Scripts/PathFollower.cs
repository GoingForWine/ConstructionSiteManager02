using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        [SerializeField]
        public PathCreator[] paths;
        public PathCreator pathInMotion;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        public float distanceTravelled;
        private float timeTravelled = 0;

        public bool forward = false;
        public bool backward = false;
        public bool stopMovement = false;
        public bool hasTurned = false;

        void Start()
        {
            //transform.position = paths[0].path.localPoints[paths[0].path.localPoints.Length - 1] + paths[0].gameObject.transform.position;

            //int i = 0;
            //foreach (var p in paths[0].path.localPoints)
            //{
            //    var go = new GameObject("TEST"+i);
            //    go.transform.position = p + paths[0].gameObject.transform.position;
            //    i++;
            //}

            //0 and last   should be = checkpoints

            if (pathInMotion != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathInMotion.pathUpdated += OnPathChanged;

                //Debug.Log("Start fired in Path follower");
                //transform.position = pathInMotion.path.localPoints[1];

                //foreach (var p in pathInMotion.path.localPoints)
                //    Debug.Log("points: " + p);
            }
        }

        void Update()
        {
            if (pathInMotion != null)
            {
                //// s=vt
                //// t=s/v
                //// t = distance / speed 
                //var distance = pathInMotion.path.cumulativeLengthAtEachVertex[1] - pathInMotion.path.cumulativeLengthAtEachVertex[0];
                //var totalTime = distance / speed;

                //timeTravelled += Time.deltaTime;
                //if (timeTravelled > totalTime)
                //{
                //    timeTravelled = totalTime;
                //    //distanceTravelled = pathInMotion.path.cumulativeLengthAtEachVertex[1];
                //    transform.position = pathInMotion.path.localPoints[pathInMotion.path.localPoints.Length - 1];
                //}
                //else
                //{
                //    distanceTravelled = distance * (timeTravelled / totalTime);
                //    transform.position = pathInMotion.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                //}
                ////distanceTravelled += speed * Time.deltaTime;
                ////transform.position = pathInMotion.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                //transform.rotation = pathInMotion.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);


                if (hasTurned)
                {
                    if (stopMovement)
                    {
                        
                        //distanceTravelled = distanceTravelled;
                    }
                    else if (forward)
                    {
                        distanceTravelled += speed * Time.deltaTime;
                        transform.rotation = pathInMotion.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                    }
                    else if (backward)
                    {
                        distanceTravelled -= speed * Time.deltaTime;
                        transform.rotation = pathInMotion.path.GetBackwardRotationAtDistance(distanceTravelled, endOfPathInstruction);
                    }


                }

                transform.position = pathInMotion.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);

            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged()
        {
            distanceTravelled = pathInMotion.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}