using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{   
    [Header ("UI Parameters")]
    [SerializeField] private GameObject tutorialUI;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {   
            tutorialUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {   
            tutorialUI.SetActive(false);
        }
    }
}
