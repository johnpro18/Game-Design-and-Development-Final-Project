using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollectibles : MonoBehaviour
{
    [SerializeField] private int shieldValue = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            collider.GetComponent<PlayerHealth>().AddShield(shieldValue);
            gameObject.SetActive(false);
        }
    }
}
