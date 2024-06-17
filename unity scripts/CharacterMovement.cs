using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float walkSpeed = 2.0f;
    public float runSpeed = 4.0f;
    private Animator animator;
    private Vector3 movement;

    void Start()
    {
        // Find the Animator component in this GameObject or its children
        animator = GetComponentInChildren<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on this GameObject or its children.");
        }
        else if (!animator.runtimeAnimatorController)
        {
            Debug.LogError("Animator component found, but no Animator Controller assigned.");
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Update the movement vector
        movement = new Vector3(horizontal, 0.0f, vertical).normalized;

        // Check for specific keys for walking and running
        if (Input.GetKey(KeyCode.W))
        {
            MoveCharacter(walkSpeed);
            Debug.Log("Walking");
        }
        else if (Input.GetKey(KeyCode.R))
        {
            MoveCharacter(runSpeed);
            Debug.Log("Running");
        }
        else if (movement.magnitude > 0)
        {
            // Default to walking if any movement input is detected
            MoveCharacter(walkSpeed);
            Debug.Log("Walking");
        }
        else
        {
            // Set Speed to 0 when there's no movement
            animator.SetFloat("Speed", 0);
            Debug.Log("Idle");
        }
    }

    void MoveCharacter(float currentSpeed)
    {
        // Move the character
        transform.Translate(movement * currentSpeed * Time.deltaTime, Space.World);
        // Update the Speed parameter in the Animator
        animator.SetFloat("Speed", currentSpeed);
        Debug.Log("Speed set to: " + currentSpeed);
    }
}