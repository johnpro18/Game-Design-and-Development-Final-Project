using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complete : MonoBehaviour
{
    [Header ("UI Parameters")]
    [SerializeField] private GameObject victoryMenuUI;

    [Header ("Audio Parameters")]
    [SerializeField] [Range(0, 1)] private float audioVolume;
    [SerializeField] private AudioClip victoryAudio;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            Debug.Log("P002");
            victoryMenuUI.SetActive(true);
            AudioSource.PlayClipAtPoint(victoryAudio, transform.position, audioVolume);
        }
    }
}
