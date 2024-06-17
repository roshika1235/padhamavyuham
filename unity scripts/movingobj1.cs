using UnityEngine;

public class MovingWall : MonoBehaviour
{
    // Public variables to set the start and end points of the wall movement
    public Vector3 startPoint;
    public Vector3 endPoint;
    // Speed at which the wall will move
    public float speed = 1.0f;

    // Private variable to keep track of the direction of movement
    private bool movingToEnd = true;

    void Start()
    {
        // Initialize the starting position of the wall
        transform.position = startPoint;
    }

    void Update()
    {
        // Calculate the step size for this frame
        float step = speed * Time.deltaTime;

        // Move the wall towards the target point (endPoint or startPoint)
        if (movingToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint, step);

            // Check if the wall has reached the end point
            if (Vector3.Distance(transform.position, endPoint) < 0.001f)
            {
                movingToEnd = false; // Change direction
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint, step);

            // Check if the wall has reached the start point
            if (Vector3.Distance(transform.position, startPoint) < 0.001f)
            {
                movingToEnd = true; // Change direction
            }
        }
    }

    // Optional: Visualize the path in the Unity Editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startPoint, endPoint);
    }
}