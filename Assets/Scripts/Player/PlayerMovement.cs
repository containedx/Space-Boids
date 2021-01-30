using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float mass = 5f;
    public float jumpHeight = 3f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;
    
    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();
        Move();
        HandleJumping();
        ApplyGravity();       
    }

    // ----------------------------------------------------------------------------------------------------------------------------------------

    void ApplyGravity()
    {
        if (isGrounded && velocity.y < 0)  // stop from increasing velocity when grounded
        {
            velocity.y = -2f;
        }

        // Add gravity
        velocity.y += gravity * mass * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void HandleJumping()
    {
        if(Input.GetButtonDown("Jump") && isGrounded) // "Jump" key is by default Space
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity * mass); // equation for velocity needed to jump specific height : v = sqrt(h*2g)
        }
    }    

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z) * speed * Time.deltaTime;
        characterController.Move(move);
    }

    void CheckIfGrounded()
    {
        //Check if is on the ground with tiny spehere 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}
