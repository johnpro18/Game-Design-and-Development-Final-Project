using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectibles : MonoBehaviour
{
    [Header ("Coin Parameters")]
    [SerializeField] private int coinValue = 1;
    public CoinsCounter coinsCounter;

    [Header ("Audio Parameters")]
    [SerializeField] [Range(0, 1)] private float audioVolume;
    [SerializeField] private AudioClip collectibleAudio;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            coinsCounter.SetCoinsCounter(coinValue);
            AudioSource.PlayClipAtPoint(collectibleAudio, transform.position, audioVolume);
            gameObject.SetActive(false);
        }
    }
}
