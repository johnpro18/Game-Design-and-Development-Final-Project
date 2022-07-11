using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollectibles : MonoBehaviour
{
    [Header ("Shield Parameters")]
    [SerializeField] private int shieldValue = 1;

    [Header ("Audio Parameters")]
    [SerializeField] [Range(0, 1)] private float audioVolume;
    [SerializeField] private AudioClip collectibleAudio;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            collider.GetComponent<PlayerHealth>().AddShield(shieldValue);
            AudioSource.PlayClipAtPoint(collectibleAudio, transform.position, audioVolume);
            gameObject.SetActive(false);
        }
    }
}
