using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerHealth : MonoBehaviour
{
    [Header ("Health Parameters")]
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int maxShield = 10;

    [Header ("UI Parameters")]
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private ShieldBar shieldBar;
    [SerializeField] private GameObject defeatUI;

    [Header ("Audio Parameters")]
    [SerializeField] private AudioClip damageAudio;
    [SerializeField] private AudioClip defeatAudio;

    private int currentHealth;
    private int currentShield; 

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        currentShield = maxShield;
        healthBar.SetMaxHealth(maxHealth);
        shieldBar.SetMaxShield(maxShield);
    }

    public void TakeDamage(int damage)
    {
        if(currentShield > 0)
        {
            currentShield = Mathf.Clamp(currentShield - damage, 0, maxShield);
            shieldBar.SetShield(currentShield);
        }
        else
        {
            currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                animator.SetTrigger("Death");
                DefeatTrigger();
            }
        }
    }

    public void AddHealth(int value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void AddShield(int value)
    {
        currentShield = Mathf.Clamp(currentShield + value, 0, maxShield);
        shieldBar.SetShield(currentShield);
    }

    public void DeleteObject()
    {
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
    }

    public void DefeatTrigger()
    {
        Debug.Log("Dead");
        defeatUI.SetActive(true);
        AudioSource.PlayClipAtPoint(defeatAudio, transform.position);
    }
}
