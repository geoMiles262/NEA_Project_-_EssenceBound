using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Movement Settings")]
    public float walkSpeed = 5f; // Player movement speed  

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveDirection;
    private Animator animator;
    private Vector2 lastMoveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.gravityScale = 0; // Disable gravity for top-down movement
    }   


    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        //check shift for sprinting
        float movespeed = walkSpeed;

        //gets velocity
        rb.linearVelocity = moveInput * movespeed;

        // Remember last direction when moving
        if (moveInput.sqrMagnitude > 0)
            lastMoveDirection = moveInput;

        //set animator parameters
        if (animator != null)
        {
            animator.SetFloat("MoveX", moveInput.x);
            animator.SetFloat("MoveY", moveInput.y);
            animator.SetFloat("Speed", moveDirection.sqrMagnitude);
        }

        //Update animator based on direction and speed
        if (moveInput.x > 0)
            animator.Play("Walk_Right");
        else if (moveInput.x < 0)
            animator.Play("Walk_Left");
        else if (moveInput.y > 0)
            animator.Play("Walk_Back");
        else if (moveInput.y < 0)
            animator.Play("Walk_Front");
        else
        {
            {
                // No movement → idle facing last direction
                if (lastMoveDirection.x > 0)
                    animator.Play("Idle_Right");
                else if (lastMoveDirection.x < 0)
                    animator.Play("Idle_Left");
                else if (lastMoveDirection.y > 0)
                    animator.Play("Idle_Back");
                else
                    animator.Play("Idle_Front");
            }
        }
    }
}
