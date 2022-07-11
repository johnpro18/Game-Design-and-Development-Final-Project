using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{   
    [Header ("Health Parameters")]
    [SerializeField] private int maxHealth = 10; 
    [SerializeField] public HealthBar healthBar;

    private int currentHealth;
    
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            animator.SetTrigger("Death");
            Debug.Log("E001");
        }
    }

    public void DeleteObject()
    {
        Destroy(gameObject);
    }
}
