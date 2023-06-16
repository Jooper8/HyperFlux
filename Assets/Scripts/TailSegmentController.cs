using UnityEngine;

public class TailSegmentController : MonoBehaviour
{
    public Transform target;
    public float followDistance = 0.5f;
    public float interpolationFactor = 15f;
    private Vector3 targetPosition;

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target not assigned");
            return;
        }
        targetPosition = target.position;
    }

    private void Update()
    {
        if (target == null)
            return;
        Vector3 desiredPosition = targetPosition - (target.up * followDistance);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * interpolationFactor);
        targetPosition = target.position;
    }
}
