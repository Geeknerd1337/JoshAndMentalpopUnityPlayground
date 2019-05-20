using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ThieveControl : MonoBehaviour
{

    public float time = 0.0f;
    public Text t;
    public Text t2;

    public int totalValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        t.text = FormatSeconds(time);
        t2.text = "Total items Value: " + totalValue.ToString();


    }

    string FormatSeconds(float elapsed)
    {
        int d = (int)(elapsed * 100.0f);
        int minutes = d / (60 * 100);
        int seconds = (d % (60 * 100)) / 100;
        int hundredths = d % 100;
        return String.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
