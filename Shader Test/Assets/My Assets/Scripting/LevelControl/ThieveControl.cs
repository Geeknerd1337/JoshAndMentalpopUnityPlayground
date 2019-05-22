using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Invector.CharacterController;

public class ThieveControl : MonoBehaviour
{

    public float time = 0.0f;
    public Text t;
    public Text t2;
    private int lastMinute;
    public AudioSource tick;
    public int totalValue;

    private int valueActual = 0;
    //Player's total weight tolerance
    public float weightTotal = 100;
    public float currWeight;
    public vThirdPersonMotor playerMotor;
    // Start is called before the first frame update
    void Start()
    {
        lastMinute = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        t.text = FormatSeconds(time);

        valueActual = (int)Mathf.Lerp(valueActual, totalValue, 0.3f);
        t2.text = "Total items Value: " + valueActual.ToString();

        currWeight = Inventory.instance.ReturnWeights();
        playerMotor.weightCoef = Mathf.Clamp(1.0f - (currWeight / weightTotal), 0, 1.0f);

    }

    string FormatSeconds(float elapsed)
    {

        int d = (int)(elapsed * 100.0f);
        int minutes = d / (60 * 100);


        int seconds = (d % (60 * 100)) / 100;
        if (seconds != lastMinute)
        {
            tick.Play();
            lastMinute = seconds;
        }
        int hundredths = d % 100;
        return String.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
