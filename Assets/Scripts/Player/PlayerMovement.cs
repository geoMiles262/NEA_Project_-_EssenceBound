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
            // Idle based on last faced direction
            AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
            if (state.IsName("Walk_Right") || state.IsName("Run_Right")) animator.Play("Idle_Right");
            else if (state.IsName("Walk_Left") || state.IsName("Run_Left")) animator.Play("Idle_Left");
            else if (state.IsName("Walk_Back") || state.IsName("Run_Back")) animator.Play("Idle_Back");
            else animator.Play("Idle_Front");
        }
    }
}
