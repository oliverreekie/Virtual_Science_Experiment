using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class WiresScript : MonoBehaviour
{
    //If card is passing through
    private bool running = false;

    //Initially timer value is 0 
    private double timer = 0;

    public TextMeshPro uiText;

    void Update()
    {
        if(running == true)
        {
            //Increment time considering frame rate
            timer += Time.deltaTime;
        }
        else
        {
            //Print value rounded and to 3 decimal places
            double toPrint = Math.Round((timer * 10), 4);
            uiText.text = toPrint.ToString("0.000");
        }
    }

    //Start timer when card first starts colliding with laser
    private void OnTriggerEnter(Collider other)
    {
        running = true;
        timer = 0;
    }

    //Stop timer when card stops colliding with laser
    private void OnTriggerExit(Collider other)
    {
        running = false;
    }
}
