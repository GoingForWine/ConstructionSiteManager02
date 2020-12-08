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

        void Start()
        {
            if (pathInMotion != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathInMotion.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathInMotion != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathInMotion.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathInMotion.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
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