using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GradingTracker : MonoBehaviour
{
    //List of references to the graph labels
    public List<GameObject> graphLabels;

    //List of the table headers
    public List<TMP_InputField> graphHeaders;

    //List of the grid line labels
    public List<GameObject> graphLineLabels;

    //List of all input fields in the table
    public List<TMP_InputField> allTableFields;

    //List of the graph points
    public List<GameObject> graphPoints;

    //Holds the user calculated gradient
    public double calculatedGradient;

}

