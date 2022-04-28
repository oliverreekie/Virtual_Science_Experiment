using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GradingSystem : MonoBehaviour
{

    public TMP_InputField xDifference;
    public TMP_InputField yDifference;

    public Button enterButton;

    public Button submitButton;

    public TextMeshProUGUI gradient1;
    public TextMeshProUGUI gradient2;

    public GameObject stage1;
    public GameObject stage2;

    public TextMeshProUGUI independentLabel;
    public TextMeshProUGUI dependentLabel;
    public TextMeshProUGUI graphLabelsLabel;

    //Graph Axis
    public Image axisMarkerBotttomLeft;
    public Image axisMarkerTopRight;
    public Image axisMarkerUnderGraph;

    public GradingTracker gradingTracker;

    // Start is called before the first frame update
    void Start()
    {
        enterButton.onClick.AddListener(TaskOnClick);
        submitButton.onClick.AddListener(TaskOnClickSubmit);

        stage1.SetActive(true);
        stage2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        float x = float.Parse(xDifference.text);
        float y = float.Parse(yDifference.text);

        float g = x / y;

        gradient1.text = g.ToString();
        gradient2.text = g.ToString();
    }

    void TaskOnClickSubmit()
    {
        stage1.SetActive(false);
        stage2.SetActive(true);

        CheckVariables();

        CheckGraphLabels();
    }

    void CheckVariables()
    {
        if(BuildState.Instance.independentVariable.Contains("Distance") || 
            BuildState.Instance.independentVariable.Contains("distance") || 
            BuildState.Instance.independentVariable == "d" || 
            BuildState.Instance.independentVariable == "D")
        {
            independentLabel.text = "5/5";
        }
        else if(BuildState.Instance.independentVariable.Contains("Height") ||
            BuildState.Instance.independentVariable.Contains("height") ||
            BuildState.Instance.independentVariable == "h" ||
            BuildState.Instance.independentVariable == "H")
        {
            independentLabel.text = "3/5";
        }
        else
        {
            independentLabel.text = "0/5";
        }

        if (BuildState.Instance.dependentVariable.Contains("Velocity") || 
            BuildState.Instance.dependentVariable.Contains("velocity") || 
            BuildState.Instance.dependentVariable == "v" || 
            BuildState.Instance.dependentVariable == "V"|| 
            BuildState.Instance.dependentVariable.Contains("Time") || 
            BuildState.Instance.dependentVariable.Contains("time") || 
            BuildState.Instance.dependentVariable == "t" || 
            BuildState.Instance.dependentVariable == "T")
        {
            dependentLabel.text = "5/5";
        }
        if (BuildState.Instance.dependentVariable.Contains("Speed") ||
            BuildState.Instance.dependentVariable.Contains("speed") ||
            BuildState.Instance.dependentVariable == "s" ||
            BuildState.Instance.dependentVariable == "S")
        {
            dependentLabel.text = "3/5";
        }
        else
        {
            dependentLabel.text = "0/5";
        }
    }

    void CheckGraphLabels()
    {
        int score = 0;
        int counter = 0;
        for(int i = 0; i < gradingTracker.graphLabels.Count; i++)
        {
            if(gradingTracker.graphLabels[i].transform.position.y >= axisMarkerTopRight.transform.position.y)
            {
                if(gradingTracker.graphLabels[i].GetComponent<InputField>().text != "")
                {
                    score += 2;
                    counter += 1;
                }
            }
            else if (gradingTracker.graphLabels[i].transform.position.x <= axisMarkerBotttomLeft.transform.position.x)
            {
                if (gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("Speed") || 
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("speed") ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text == "s" ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text == "S")
                {
                    score += 1;
                    counter += 1;
                }
                else if (gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("Velocity") ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("velocity") ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text == "v" ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text == "V")
                {
                    score += 2;
                    counter += 1;
                }
            }
            else if(gradingTracker.graphLabels[i].transform.position.y <= axisMarkerBotttomLeft.transform.position.y && gradingTracker.graphLabels[i].transform.position.y >= axisMarkerUnderGraph.transform.position.y)
            {
                if (gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("Height") ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("height") ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text == "h" ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text == "H")
                {
                    score += 1;
                    counter += 1;
                }
                else if (gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("Distance") ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("distance") ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text == "d" ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text == "D")
                {
                    score += 2;
                    counter += 1;
                }
            }

            if(counter >= 3)
            {
                break;
            }
          
        }

        graphLabelsLabel.text = score + "/6"; 
    }
}
