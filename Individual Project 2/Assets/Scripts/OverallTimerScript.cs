using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OverallTimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerLabel;

    private double timerSeconds = 0;

    private int timerMinutes = 0;

    public Canvas menu;

    public GradingSystem gradingSystem;

    public string timerValue;

    void Update()
    {
        if(menu.isActiveAndEnabled == false && gradingSystem.isActiveAndEnabled == false)
        {
            timerSeconds += Time.deltaTime;

            if (timerSeconds >= 60)
            {
                timerSeconds = 0;
                timerMinutes += 1;
            }

            timerLabel.text = (timerMinutes.ToString() + "m " + timerSeconds.ToString("0.0") + "s");
            timerValue = (timerMinutes.ToString() + "m " + timerSeconds.ToString("0.0") + "s");
        }

    }
}
