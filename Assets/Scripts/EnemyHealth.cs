using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50;

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(gameObject.name + " took " + damage + " damage! Remaining health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " died!");
        // Optional: play death animation or effects here

        Destroy(gameObject); // Remove enemy from scene
    }
}
