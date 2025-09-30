using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Player movement speed  

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Disable gravity for top-down movement
    }   


    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        float moveY = Input.GetAxis("Vertical") * moveSpeed;
        moveDirection = new Vector2(moveX, moveY).normalized;
    }
    void FixedUpdate()
    {
        rb.linearVelocity = moveDirection * moveSpeed;
    }
}
