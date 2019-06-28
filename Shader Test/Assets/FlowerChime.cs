﻿using UnityEngine;
using System.Collections;

public class FlowerChime : MonoBehaviour
{

 
    public bool alreadyPlayed = false;


    private AudioSource source;
    private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;

  


    void Start()
    {

        source = GetComponent<AudioSource>();
    }


    void OnTriggerEnter()
    {
        Debug.Log("it trigger");
        if (!alreadyPlayed)
        {
            source.pitch = Random.Range(lowPitchRange, highPitchRange);
            GetComponent<AudioSource>().Play();
            alreadyPlayed = true;
            StopCoroutine("SetBoolToFalse");
            StartCoroutine("SetBoolToFalse");
        }
      
    }
    

    private IEnumerator SetBoolToFalse()
    {

        yield return new WaitForSeconds(3f);
        if (alreadyPlayed == true)
        {
            alreadyPlayed = false;
        }
        yield return null;
    }

}