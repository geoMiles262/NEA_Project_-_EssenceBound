using UnityEngine;

public class PlayerCompleteMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Movement")]
    public float moveSpeed = 5f;
    private Vector2 moveInput;

    private Rigidbody2D rb;
    private Animator animator;

    private string lastDirection = "Front";
    private bool isAttacking = false;
    private float attackDuration = 0.3f;
    private float attackTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

        // Check if currently playing an attack animation
        if (state.IsName("Attack_Front") || state.IsName("Attack_Back") ||
            state.IsName("Attack_Left") || state.IsName("Attack_Right"))
        {
            // Animation finished if normalizedTime >= 1
            if (state.normalizedTime >= 1f)
            {
                isAttacking = false; // attack finished
            }
            else
            {
                rb.linearVelocity = Vector2.zero; // stop movement while attacking
                return; // skip rest of Update
            }
        }

        if (isAttacking)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
                isAttacking = false;

            return;
        }

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        // Move
        rb.linearVelocity = moveInput * moveSpeed;

        // Save last facing direction
        if (moveInput.x > 0) lastDirection = "Right";
        else if (moveInput.x < 0) lastDirection = "Left";
        else if (moveInput.y > 0) lastDirection = "Back";
        else if (moveInput.y < 0) lastDirection = "Front";

        // Play movement animations
        if (moveInput != Vector2.zero)
        {
            animator.Play("Walk_" + lastDirection);
        }
        else
        {
            animator.Play("Idle_" + lastDirection);
        }

        // Attack input
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        isAttacking = true;
        attackTimer = attackDuration;

        // Stop movement while attacking
        rb.linearVelocity = Vector2.zero;

        // Play attack animation
        animator.CrossFade("Attack_" + lastDirection, 0f);
        Debug.Log("Attack: " + lastDirection);
    }

}
