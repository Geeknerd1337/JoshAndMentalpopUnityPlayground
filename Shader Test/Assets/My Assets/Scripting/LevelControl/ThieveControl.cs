﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Invector.CharacterController;
using UnityEngine.SceneManagement;



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
    public vThirdPersonController player;
    private bool endTrigger;

    public Text endText;

    public Text amtText;

    public int valueThreshold;

    public GameObject[] inRadius;
    public float interActionRadius;
    public Outline[] outlines;

    // Start is called before the first frame update
    void Start()
    {
        lastMinute = 0;
        endTrigger = false;
        endText.text = "";

        outlines = FindObjectsOfType<Outline>();

    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            if (endTrigger == false)
            {
                if (valueActual > valueThreshold)
                {
                    player.enabled = false;
                    endText.text = "YOU WIN";
                }
                else
                {
                    player.enabled = false;
                    endText.text = "YOU LOSE";
                }
                endTrigger = true;
            }

            if (Input.GetButtonDown("Kwit"))
            {
                SceneManager.LoadScene("HouseLevel");
            }
        }

        t.text = FormatSeconds(time);

        valueActual = (int)Mathf.Lerp(valueActual, totalValue, 0.3f);
        t2.text = "Total items Value: " + valueActual.ToString();

        currWeight = Inventory.instance.ReturnWeights();
        playerMotor.weightCoef = Mathf.Clamp(1.0f - (currWeight / weightTotal), 0, 1.0f);
        amtText.text = Inventory.instance.items.Count.ToString() + "/" + Inventory.instance.space;

        SetArray();

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


    void SetArray()
    {
        Collider[] hitColliders = Physics.OverlapSphere(player.gameObject.transform.position, interActionRadius);
        

        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.GetComponent<Outline>() != null)
            {
                hitColliders[i].gameObject.GetComponent<Outline>().enabled = true;
                Debug.Log("Worked");
            }
            i++;
        }


    }

    void ResetAllOutlines()
    {
        foreach(Outline o in outlines)
        {
            o.enabled = false;
        }
    }
}
