using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsCounter : MonoBehaviour
{
    public static CoinsCounter instance;
    public TextMeshProUGUI text;

    int coinCounter;

    // Start is called before the first frame update
    void Start()
    {
        if(instance = null)
        {
            instance = this;
        }
    }

    public void SetCoinsCounter(int value)
    {
        coinCounter += value;
        text.text = coinCounter.ToString();
    }
}
