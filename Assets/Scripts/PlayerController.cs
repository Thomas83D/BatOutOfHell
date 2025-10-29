using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float accelerationTime = 1f;
    public float decelerationTime = 1f;
    public float currentSpeed = 0f;
    public float maxSpeed;
    float acceleration;
    public float jumpVelocity;
    Vector2 velocity;

    Rigidbody2D rb;

    public LayerMask ground;
    public Transform player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 playerInput = new Vector2(Input.GetAxis("Horizontal"), 0).normalized;
        MovementUpdate(playerInput);

       // Debug.Log(IsGrounded());
    }

    private void MovementUpdate(Vector2 playerInput)
    {
        acceleration = maxSpeed / accelerationTime;

        if (playerInput.magnitude > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;

            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
            }

            velocity = playerInput * currentSpeed;
        }

        else

        {
            currentSpeed -= acceleration * Time.deltaTime;

            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }

            velocity = velocity.normalized * currentSpeed;
        }

        transform.position += (Vector3)velocity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }
    }

    public bool IsWalking()
    {
        return currentSpeed > 0;

    }
    public bool IsGrounded()
    {
        bool checkGrounded = Physics2D.Raycast(player.position, Vector2.down, 0.6f, ground);
        Debug.DrawRay(player.position, Vector2.down * 0.6f, Color.green);

        return checkGrounded;
    }


}