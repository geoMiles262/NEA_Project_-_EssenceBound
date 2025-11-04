using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public float attackRange = 1f;
    public float attackdamage = 25;
    public float attackCooldown = 0.5f;
    public LayerMask enemyLayer;

    private Animator animator;
    private string lastDirection = "Front";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLastDirection();

        if (Input.GetMouseButtonDown(0) && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
        
    }

    void UpdateLastDirection() 
    { 
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveX > 0) lastDirection = "Right";
        else if (moveX < 0) lastDirection = "Left";
        else if (moveY > 0) lastDirection = "Back";
        else if (moveY < 0) lastDirection = "Front";
    }

    void Attack() 
    {
        animator.Play("Attack_" + lastDirection);

        Vector2 attack
    }
}
