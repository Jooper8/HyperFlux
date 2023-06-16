using UnityEngine;

public class TailSegmentController : MonoBehaviour
{
    public Transform target; // Reference to the target (player) Transform
    public float followDistance = 0.5f; // Distance between each tail segment
    public float interpolationFactor = 15f; // Interpolation factor for smoother movement

    private Vector3 targetPosition; // Current target position

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("TailSegmentController: Target not assigned!");
            return;
        }

        targetPosition = target.position;
    }

    private void Update()
    {
        if (target == null)
            return;

        // Calculate the desired position for the tail segment
        Vector3 desiredPosition = targetPosition - (target.up * followDistance);

        // Move the tail segment towards the desired position using interpolation
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * interpolationFactor);

        targetPosition = target.position;
    }
}
