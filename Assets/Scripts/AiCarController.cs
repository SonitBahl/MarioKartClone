using UnityEngine;

public class AICarController : MonoBehaviour
{
    public WaypointContainer waypointContainer;
    public string playerTag = "Player"; // Tag of the player car
    public float speed = 5f;
    public float rotationSpeed = 2f;

    private int currentWaypointIndex = 0;
    private bool followPlayer = false;
    private int waypointsVisited = 0;
    private Transform playerTransform; // Reference to the player car's transform

    void Start()
    {
        if (waypointContainer == null)
        {
            Debug.LogError("WaypointContainer not assigned!");
            enabled = false;
            return;
        }

        // Find the player car by tag
        GameObject playerCar = GameObject.FindGameObjectWithTag(playerTag);
        if (playerCar != null)
        {
            playerTransform = playerCar.transform;
        }
        else
        {
            Debug.LogError("Player car not found with tag: " + playerTag);
            enabled = false;
            return;
        }
    }

    void Update()
    {
        if (!followPlayer)
        {
            FollowWaypoints();
        }
        else
        {
            FollowPlayer();
        }
    }

    void FollowWaypoints()
    {
        if (waypointContainer.waypoints.Count == 0)
        {
            Debug.LogWarning("No waypoints defined!");
            return;
        }

        Vector3 targetWaypoint = waypointContainer.waypoints[currentWaypointIndex].position;
        Vector3 direction = (targetWaypoint - transform.position).normalized;

        // Rotate towards the target waypoint
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move towards the target waypoint
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Check if the car has reached the waypoint
        float distanceToWaypoint = Vector3.Distance(transform.position, targetWaypoint);
        if (distanceToWaypoint < 1f)
        {
            // Forget about the current waypoint
            waypointContainer.waypoints.RemoveAt(currentWaypointIndex);

            // If there are no more waypoints, start following the player
            if (waypointContainer.waypoints.Count == 0)
            {
                Debug.Log("No more waypoints. Following player now.");
                followPlayer = true;
                return;
            }

            // Move to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypointContainer.waypoints.Count;
            waypointsVisited++;

            // Check if 5 waypoints have been visited
            if (waypointsVisited >= 5)
            {
                Debug.Log("Visited 5 waypoints. Following player now.");
                followPlayer = true;
            }
        }
    }

    void FollowPlayer()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player transform not assigned!");
            enabled = false;
            return;
        }

        // Calculate direction to the player
        Vector3 playerDirection = (playerTransform.position - transform.position).normalized;

        // Rotate towards the player
        Quaternion targetRotation = Quaternion.LookRotation(playerDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move towards the player
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
