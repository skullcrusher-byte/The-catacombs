
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 movementInput;
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;

    int direction = 0; // Start facing up

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Take in WASD input
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        movementInput = movementInput.normalized;

        // Check which direction the player is facing
        if (movementInput.x < 0)
        {
            direction = 3; // Left
            spriteRenderer.flipX = true;
        }
        else if (movementInput.x > 0)
        {
            direction = 2; // Right
            spriteRenderer.flipX = false;
        }
        else if (movementInput.y > 0)
        {
            direction = 0; // Up
        }
        else if (movementInput.y < 0)
        {
            direction = 1; // Down
        }

        // Tell Animator which animation to play
        animator.SetBool("IsMoving", movementInput.sqrMagnitude > 0);
        animator.SetInteger("Direction", direction);
    }

    void FixedUpdate()
    {
        // Move the player in all four directions
        rb.linearVelocity = movementInput * moveSpeed;
    }
}
