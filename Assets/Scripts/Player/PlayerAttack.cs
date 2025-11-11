using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public float attackRange = 1f;
    public float attackdamage = 25;
    public float attackCooldown = 0.5f;
    public LayerMask enemyLayer;
    private Animator animator;
    private float nextAttackTime = 0f;
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

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attack Clicked!");
            Attack();
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

        Vector2 attackDir = Vector2.zero;
        switch (lastDirection)
        {
            case "Right":
                attackDir = Vector2.right;
                break;
            case "Left":
                attackDir = Vector2.left;
                break;
            case "Back":
                attackDir = Vector2.up;
                break;
            case "Front":
                attackDir = Vector2.down;
                break;
        }

        Vector2 attackPos = (Vector2)transform.position + attackDir * attackRange;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackdamage);

        }

    }
    void OnDrawGizmosSelected() 
    {
        Vector2 attackDir = Vector2.zero;
        switch (lastDirection) 
        {
            case "Right":
                attackDir = Vector2.right;
                break;
            case "Left":
                attackDir = Vector2.left;
                break;
            case "Back":
                attackDir = Vector2.up;
                break;
            case "Front":
                attackDir = Vector2.down;
                break;
        }
        Vector2 attackPos = (Vector2)transform.position + attackDir * attackRange;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos, attackRange);
    }
}
