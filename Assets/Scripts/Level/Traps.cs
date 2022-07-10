using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    [Header ("Trap Parameters")]
    [SerializeField] private int damage = 1;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            collider.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
