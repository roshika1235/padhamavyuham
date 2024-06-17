using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public Animator anim;
    public float maxHealth;
    public float currHealth;
    public bool isDead;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currHealth = maxHealth;
    }

    void Update()
    {
        NewControls();
       // Shooting();
    }
    public float targetRotation;
    public Transform cameraT;
    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;
    public Rigidbody rb;
    public float InputVal;
    public float walkSpeed = 2;
    public float runSpeed = 6;
    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    public float currentSpeed;
    public LayerMask layers;
    // public WeaponData weaponData;
    public ParticleSystem muzzle;
    //  public bool isAttacking;
    //  public bool isDead;
    private void NewControls()
    {
        if (isDead)
            return;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(h, 0, v);//H indicates the player is moving in X axis and V indicates the player is moving in Z axis.
        Vector3 inputDir = input.normalized;//it converts the value or normalizes the value to 1
        Transform t = transform;
        targetRotation = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + cameraT.eulerAngles.y;//it is used for rotating the player on the camera inputs.
        t.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(t.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);//this is used for assigning the target rotation value to the player.
        InputVal = input.magnitude;
        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetspeed = ((running) ? runSpeed : walkSpeed) * input.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetspeed, ref speedSmoothVelocity, speedSmoothTime);
        // t.Translate(currentSpeed * Time.deltaTime * t.forward, Space.World);
        Vector3 velocity = transform.forward; // Calculate the velocity

        rb.velocity = velocity * currentSpeed; // Set the Rigidbody's velocity
        if (anim == null)
            return;
        if (InputVal <= 0)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
            return;
        }
        if (running)
        {
            Debug.Log("Player is Running");
            anim.SetBool("isRunning", true);
            anim.SetBool("isWalking", false);
        }
        else
        {
            Debug.Log("Player is walking");
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", false);
        }
    }
    public float fireRate = 15f;
    public float nextTimeToFire;
    private bool running;

}
    //public void TakeDamage(float health)
    // {
    //     if (isDead)
    //        return;
    //    if (currHealth <= 0 && !isDead)
    //     {
    //         isDead = true;
    //        anim.SetTrigger("Dead");
    //
    //[Serializable]
 //