using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OverallTimerScript : MonoBehaviour
{
    //The label for the timer
    public TextMeshProUGUI timerLabel;

    //Current timer information
    private double timerSeconds = 0;
    private int timerMinutes = 0;

    public Canvas menu;

    public GradingSystem gradingSystem;

    //Timer value to set
    public string timerValue;

    void Update()
    {
        //Freeze timer if menu or grading system is open
        if(menu.isActiveAndEnabled == false && gradingSystem.isActiveAndEnabled == false)
        {
            //Add time to timer considering framerate
            timerSeconds += Time.deltaTime;

            //Increment minutes when seconds reaches 60
            if (timerSeconds >= 60)
            {
                timerSeconds = 0;
                timerMinutes += 1;
            }

            //Set labels to current time
            timerLabel.text = (timerMinutes.ToString() + "m " + timerSeconds.ToString("0.0") + "s");
            timerValue = (timerMinutes.ToString() + "m " + timerSeconds.ToString("0.0") + "s");
        }

    }
}
