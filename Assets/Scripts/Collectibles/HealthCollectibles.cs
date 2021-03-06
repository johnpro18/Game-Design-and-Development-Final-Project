using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectibles : MonoBehaviour
{
    [Header ("Health Parameters")]
    [SerializeField] private int healthValue = 1;

    [Header ("Audio Parameters")]
    [SerializeField] [Range(0, 1)] private float audioVolume;
    [SerializeField] private AudioClip collectibleAudio;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            collider.GetComponent<PlayerHealth>().AddHealth(healthValue);
            AudioSource.PlayClipAtPoint(collectibleAudio, transform.position, audioVolume);
            gameObject.SetActive(false);
        }
    }
}
