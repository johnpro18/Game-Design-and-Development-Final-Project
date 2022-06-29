using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{   
    [Header ("Health Parameters")]
    [SerializeField] private int maxHealth = 10; 
    [SerializeField] public HealthBar healthBar;

    private BoxCollider2D boxCollider;
    private Animator animator;
    private Rigidbody2D body;

    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            animator.SetTrigger("Death");
            Destroy(gameObject);
        }
    }
}
