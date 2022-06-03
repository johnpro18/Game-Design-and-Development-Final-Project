using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public int maxShield = 10;
    public int currentShield; 

    public HealthBar healthBar;
    public ShieldBar shieldBar;
    protected Animator animator;
    private BoxCollider2D boxCollider;
    private Rigidbody2D body;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        currentShield = maxShield;
        healthBar.SetMaxHealth(maxHealth);
        shieldBar.SetMaxShield(maxShield);
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(2);
        }

        if (Input.GetKeyDown(KeyCode.R) && currentHealth <= 0)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        healthBar.SetHealth(maxHealth);
        shieldBar.SetShield(maxShield); currentHealth = maxHealth;
        currentShield = maxShield;
        healthBar.SetMaxHealth(maxHealth);
        shieldBar.SetMaxShield(maxShield);
        animator.SetTrigger("Idle");
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<PlayerWeapon>().enabled = true;
    }


    public void TakeDamage(int damage)
    {
        if(currentShield > 0)
        {
            currentShield -= damage;
            shieldBar.SetShield(currentShield);
            animator.SetTrigger("Hurt");
        }
        else
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            animator.SetTrigger("Hurt");

            if (currentHealth <= 0)
            {
                animator.SetTrigger("Death");
                //GetComponent<BoxCollider2D>().enabled = false;
                Vector2 deathSize = new Vector2(0.5f, 0.3f);
                boxCollider.size = deathSize;
                GetComponent<PlayerMovement>().enabled = false;
                GetComponent<PlayerWeapon>().enabled = false;
            }
        }
    }
}
