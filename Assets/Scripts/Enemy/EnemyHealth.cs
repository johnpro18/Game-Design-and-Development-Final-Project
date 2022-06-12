using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public HealthBar healthBar;
    private BoxCollider2D boxCollider;
    protected Animator animator;
    private Rigidbody2D body;

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
            //GetComponent<BoxCollider2D>().enabled = false;
            Vector2 deathSize = new Vector2(0.5f, 0.3f);
            boxCollider.size = deathSize;
            /* GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerWeapon>().enabled = false; */
        }
    }
}
