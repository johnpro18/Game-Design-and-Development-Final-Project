using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectibles : MonoBehaviour
{
    [SerializeField] private int healthValue = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            collider.GetComponent<PlayerHealth>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
