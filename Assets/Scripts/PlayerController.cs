using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float accelerationTime = 2f;
    public float maxSpeed = 5f;
    private float currentSpeed = 0f;
    private float acceleration;
    private Vector2 velocity;

    public float jumpVelocity = 7f;

    public Transform player;
    public LayerMask ground;

    private Rigidbody2D rb;

    public SpriteRenderer sprite;

    public Animator animator;
    bool isWalking = false;

    public FacingDirection currentDirection = FacingDirection.right;

    public enum FacingDirection
    {
        left, right
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        acceleration = maxSpeed / accelerationTime;

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        Debug.Log(IsGrounded());
    }

    void FixedUpdate()
    {
        Vector2 playerInput = new Vector2(Input.GetAxis("Horizontal"), 0);

        MovementUpdate(playerInput);
    }

    private void MovementUpdate(Vector2 playerInput)
    {
        
        if (IsTouchingWall())
        {
            playerInput.x = 0;
        }

        if (playerInput.x != 0)
        {
            isWalking = true;
            currentSpeed += acceleration * Time.deltaTime;
            if (currentSpeed > maxSpeed)
                currentSpeed = maxSpeed;
        }
        else
        {
            isWalking = false;
            currentSpeed -= acceleration * Time.deltaTime;
            if (currentSpeed < 0)
                currentSpeed = 0;
        }

        rb.velocity = new Vector2(playerInput.x * currentSpeed, rb.velocity.y);

        GetFacingDirection();

        if (isWalking)
        {
            animator.Play("batwalk");
        }
        else
        {
            animator.Play("batidle");
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
    }

    private bool IsGrounded()
    {
        bool grounded = Physics2D.Raycast(player.position, Vector2.down, 0.4f, ground);
        Debug.DrawRay(player.position, Vector2.down * 0.4f, Color.green);
        return grounded;
    }

    private bool IsTouchingWall()
    {
        Vector2 direction;

        if (currentDirection == FacingDirection.right)
        {
            bool touchingWall = Physics2D.Raycast(player.position + new Vector3(this.gameObject.GetComponent<BoxCollider2D>().size.x / 2, this.gameObject.GetComponent<BoxCollider2D>().size.y / 2, 0), Vector2.down, 0.55f, ground);
            Debug.DrawRay(player.position + new Vector3(this.gameObject.GetComponent<BoxCollider2D>().size.x / 2, this.gameObject.GetComponent<BoxCollider2D>().size.y / 2, 0), Vector2.down * 0.55f, Color.red);
            return touchingWall;
        }
        else
        {
            bool touchingWall = Physics2D.Raycast(player.position - new Vector3(this.gameObject.GetComponent<BoxCollider2D>().size.x / 2, -1 * this.gameObject.GetComponent<BoxCollider2D>().size.y / 2, 0), Vector2.down, 0.55f, ground);
            Debug.DrawRay(player.position - new Vector3(this.gameObject.GetComponent<BoxCollider2D>().size.x / 2, -1 * this.gameObject.GetComponent<BoxCollider2D>().size.y / 2, 0), Vector2.down * 0.55f, Color.red);
            return touchingWall;
        }

        
       

        
        

    }

    public FacingDirection GetFacingDirection()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Debug.Log(horizontalInput);

        if (horizontalInput > 0)
        {
            currentDirection = FacingDirection.right;
            sprite.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            currentDirection = FacingDirection.left;
            sprite.flipX = true;
        }

        return currentDirection;
    }
}
