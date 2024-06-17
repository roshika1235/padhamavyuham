
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHuman : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float jumpForce = 5f; // Force applied for jumping
    public LayerMask groundLayers; // Layer to identify as ground
    public Transform groundCheck; // Position to check if player is grounded
    public float groundCheckRadius = 0.2f; // Radius for ground check

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayers);

        // Handle movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ);
        //transform.Translate(movement, Space.Self);

        rb.velocity = moveSpeed * movement;
        // Handle jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    //private void OnDrawGizmos()
   // {
        // Visualize the ground check radius in the scene view
   //     Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
   // }
}
