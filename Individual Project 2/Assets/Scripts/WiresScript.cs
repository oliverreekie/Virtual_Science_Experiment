using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class WiresScript : MonoBehaviour
{
    private bool running = false;

    private double timer = 0;

    public TextMeshPro uiText;

    void Update()
    {
        if(running == true)
        {
            timer += Time.deltaTime;
        }
        else
        {
            //print(timer);
            double toPrint = Math.Round((timer * 10), 4);
            uiText.text = toPrint.ToString("0.000");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("collide");
        running = true;
        timer = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        print("out");
        running = false;
    }
}
