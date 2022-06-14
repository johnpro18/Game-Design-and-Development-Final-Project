using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectibles : MonoBehaviour
{
    [SerializeField] private int coinValue = 1;

    public CoinsCounter coinsCounter;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            coinsCounter.SetCoinsCounter(coinValue);
            gameObject.SetActive(false);
        }
    }
}
