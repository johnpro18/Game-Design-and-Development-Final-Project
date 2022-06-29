using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header ("Projectile Parameters")]
    [SerializeField] private float projectileSpeed = 20f;
    [SerializeField] private int projectileDamage = 1;
    
    public Rigidbody2D body;
    
    // Start is called before the first frame update
    private void Start()
    {
        body.velocity = transform.right * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Enemy")
        {
            collider.GetComponent<EnemyHealth>().TakeDamage(projectileDamage);
            Destroy(gameObject);
        }
        else if(collider.tag == "Map")
        {
            Destroy(gameObject);
        }
    }
}
