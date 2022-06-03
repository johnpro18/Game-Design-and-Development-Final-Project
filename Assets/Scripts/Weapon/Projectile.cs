using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 20f;
    public int projectileDamage = 40;
    
    public Rigidbody2D body;
    public GameObject impactEffect;
    
    // Start is called before the first frame update
    private void Start()
    {
        body.velocity = transform.right * projectileSpeed;
    }

    private void OnTriggerEvent(Collider2D hitInfo)
    {
        /* Enemy enemy = hitInfo.GetComponent<Enemy>();

        if(enemy != null)
        {
            enemy.TakeDamage(projectileDamage);
        } */

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }

}
