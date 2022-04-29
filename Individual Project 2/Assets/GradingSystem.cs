using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class GradingSystem : MonoBehaviour
{
    private bool hasPressedEnter;

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
    public TextMeshProUGUI tableUnitsLabel;
    public TextMeshProUGUI gravityLabel;
    public TextMeshProUGUI gridLineLabelsLabel;
    public TextMeshProUGUI blankTableLabel;
    public TextMeshProUGUI totalMark;
    public TextMeshProUGUI timer;

    //Graph Axis
    public Image axisMarkerBotttomLeft;
    public Image axisMarkerTopRight;
    public Image axisMarkerUnderGraph;

    public GradingTracker gradingTracker;

    private float gravityValue;

    private int mark;

    //Grade Images

    public GameObject gradeA;
    public GameObject gradeB;
    public GameObject gradeC;
    public GameObject gradeD;
    public GameObject gradeE;

    public OverallTimerScript overallTimer;

    // Start is called before the first frame update
    void Start()
    {
        enterButton.onClick.AddListener(TaskOnClick);
        submitButton.onClick.AddListener(TaskOnClickSubmit);

        stage1.SetActive(true);
        stage2.SetActive(false);

        hasPressedEnter = false;

        gradeA.SetActive(false);
        gradeB.SetActive(false);
        gradeC.SetActive(false);
        gradeD.SetActive(false);
        gradeE.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        if(xDifference.text != "" && yDifference.text != "")
        {
            float x = float.Parse(xDifference.text);
            float y = float.Parse(yDifference.text);

            float g = x / y;

            gradient1.text = g.ToString();
            gradient2.text = g.ToString();

            gravityValue = g;

            hasPressedEnter = true;
        }
    }

    void TaskOnClickSubmit()
    {
        if(hasPressedEnter == true)
        {
            stage1.SetActive(false);
            stage2.SetActive(true);

            CheckVariables();

            CheckGraphLabels();

            CheckGraphHeaders();

            CheckGravityValue();

            CheckGraphLineLabels();

            CheckEmptyFields();

            SetTotal();

            timer.text = overallTimer.timerValue;
        }
    }

    void CheckVariables()
    {
        if(BuildState.Instance.independentVariable.Contains("Distance") || 
            BuildState.Instance.independentVariable.Contains("distance") || 
            BuildState.Instance.independentVariable == "d" || 
            BuildState.Instance.independentVariable == "D" ||
            BuildState.Instance.independentVariable.Contains("(D)") ||
            BuildState.Instance.independentVariable.Contains("(d)"))
        {
            independentLabel.text = "5/5";
            mark += 5;
        }
        else if(BuildState.Instance.independentVariable.Contains("Height") ||
            BuildState.Instance.independentVariable.Contains("height") ||
            BuildState.Instance.independentVariable == "h" ||
            BuildState.Instance.independentVariable == "H" ||
            BuildState.Instance.independentVariable.Contains("(H)") ||
            BuildState.Instance.independentVariable.Contains("(h)"))
        {
            independentLabel.text = "3/5";
            mark += 3;
        }
        else
        {
            independentLabel.text = "0/5";
        }

        if (BuildState.Instance.dependentVariable.Contains("Velocity") || 
            BuildState.Instance.dependentVariable.Contains("velocity") || 
            BuildState.Instance.dependentVariable == "v" || 
            BuildState.Instance.dependentVariable == "V"||
            BuildState.Instance.dependentVariable.Contains("(V)") ||
            BuildState.Instance.dependentVariable.Contains("(v)") ||
            BuildState.Instance.dependentVariable.Contains("Time") || 
            BuildState.Instance.dependentVariable.Contains("time") || 
            BuildState.Instance.dependentVariable == "t" || 
            BuildState.Instance.dependentVariable == "T" ||
            BuildState.Instance.dependentVariable.Contains("(T)") ||
            BuildState.Instance.dependentVariable.Contains("(t)"))
        {
            dependentLabel.text = "5/5";
            mark += 5;
        }
        else if (BuildState.Instance.dependentVariable.Contains("Speed") ||
            BuildState.Instance.dependentVariable.Contains("speed") ||
            BuildState.Instance.dependentVariable == "s" ||
            BuildState.Instance.dependentVariable == "S" ||
            BuildState.Instance.dependentVariable.Contains("(S)") ||
            BuildState.Instance.dependentVariable.Contains("(s)"))
        {
            dependentLabel.text = "3/5";
            mark += 3;
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
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text == "S" ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("(s)") ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("(S)"))
                {
                    score += 1;
                    counter += 1;
                }
                else if (gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("Velocity") ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("velocity") ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text == "v" ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text == "V" ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("(V)") ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("(v)"))
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
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text == "H" ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("(H)") ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("(h)"))
                {
                    score += 1;
                    counter += 1;
                }
                else if (gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("Distance") ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("distance") ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text == "d" ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text == "D" ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("(D)") ||
                    gradingTracker.graphLabels[i].GetComponent<InputField>().text.Contains("(d)"))
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
        mark += score;
        graphLabelsLabel.text = score + "/6"; 
    }

    void CheckGraphHeaders()
    {
        int unitMarks = 0;
        int count = 0;

        for(int i = 0; i < gradingTracker.graphHeaders.Count; i++)
        {
            if(gradingTracker.graphHeaders[i].text.Contains("(s)"))
            {
                unitMarks += 2;
            }
            else if(gradingTracker.graphHeaders[i].text.Contains("(m/s)"))
            {
                unitMarks += 2;
            } 
            else if (gradingTracker.graphHeaders[i].text.Contains("(m)"))
            {
                unitMarks += 2;
            }
            else if (gradingTracker.graphHeaders[i].text.Contains("(cm)"))
            {
                unitMarks += 1;
            }

            count += 1;

            if (count >= 6)
            {
                break;
            }
        }

        mark += unitMarks / 2;

        tableUnitsLabel.text = (unitMarks / 2) + "/6";

    }

    void CheckGravityValue()
    {
        if(gravityValue >= 9 && gravityValue <= 10)
        {
            gravityLabel.text = "5/5";
            mark += 5;
        }
        else if((gravityValue >= 8 && gravityValue <= 9) || (gravityValue >= 10 && gravityValue <= 11))
        {
            gravityLabel.text = "4/5";
            mark += 4;
        }
        else if ((gravityValue >= 7 && gravityValue <= 8) || (gravityValue >= 11 && gravityValue <= 12))
        {
            gravityLabel.text = "3/5";
            mark += 3;
        }
        else if ((gravityValue >= 6 && gravityValue <= 7) || (gravityValue >= 12 && gravityValue <= 13))
        {
            gravityLabel.text = "2/5";
            mark += 2;
        }
        else if ((gravityValue >= 5 && gravityValue <= 5) || (gravityValue >= 13 && gravityValue <= 14))
        {
            gravityLabel.text = "1/5";
            mark += 1;
        }
        else
        {
            gravityLabel.text = "0/5";
        }
    }

    void CheckGraphLineLabels()
    {
        int marks = 0;

        List<GameObject> yAxisLabels = new List<GameObject>();
        List<GameObject> xAxisLabels = new List<GameObject>();

        //Create lists of all the x axis labels and y axis labels
        for (int i = 0; i < gradingTracker.graphLineLabels.Count; i++)
        {
            if(gradingTracker.graphLineLabels[i].transform.position.x <= axisMarkerBotttomLeft.transform.position.x)
            {
                yAxisLabels.Add(gradingTracker.graphLineLabels[i]);
            }
            else
            {
                if(gradingTracker.graphLineLabels[i].transform.position.y >= axisMarkerUnderGraph.transform.position.y)
                {
                    xAxisLabels.Add(gradingTracker.graphLineLabels[i]);
                }
            }
        }

        //Remove from list if inputfield is empty
        yAxisLabels.RemoveAll(x => x.GetComponent<TMP_InputField>().text == "");
        xAxisLabels.RemoveAll(x => x.GetComponent<TMP_InputField>().text == "");

        //Sorting by position
        yAxisLabels = yAxisLabels.OrderBy(yAxisLabels => yAxisLabels.transform.position.y).ToList();
        xAxisLabels = xAxisLabels.OrderBy(xAxisLabels => xAxisLabels.transform.position.x).ToList();

        //Check if increasing linearly
        bool linearCheckY = true;
        float linearHolderY = 0;

        for(int i = 0; i < yAxisLabels.Count - 1; i++)
        {
            float diff = float.Parse(yAxisLabels[i + 1].GetComponent<TMP_InputField>().text) - float.Parse(yAxisLabels[i].GetComponent<TMP_InputField>().text);

            if (i == 0)
            {
                linearHolderY = diff;
            }
            else
            {
                if(diff != linearHolderY)
                {
                    linearCheckY = false;
                    break;
                }
            }
        }

        bool linearCheckX = true;
        float linearHolderX = 0;

        for (int i = 0; i < xAxisLabels.Count - 1; i++)
        {
            float diff = float.Parse(xAxisLabels[i + 1].GetComponent<TMP_InputField>().text) - float.Parse(xAxisLabels[i].GetComponent<TMP_InputField>().text);

            if (i == 0)
            {
                linearHolderX = diff;
            }
            else
            {
                if (diff != linearHolderX)
                {
                    linearCheckX = false;
                    break;
                }
            }
        }

        //Check if increasing exponentially
        bool expCheckY = true;
        float expHolderY = 0;

        for (int i = 0; i < yAxisLabels.Count - 1; i++)
        {
            float diff = float.Parse(yAxisLabels[i + 1].GetComponent<TMP_InputField>().text) / float.Parse(yAxisLabels[i].GetComponent<TMP_InputField>().text);

            if (i == 0)
            {
                expHolderY = diff;
            }
            else
            {
                if (diff != expHolderY)
                {
                    expCheckY = false;
                    break;
                }
            }
        }

        bool expCheckX = true;
        float expHolderX = 0;

        for (int i = 0; i < xAxisLabels.Count - 1; i++)
        {
            float diff = float.Parse(xAxisLabels[i + 1].GetComponent<TMP_InputField>().text) / float.Parse(xAxisLabels[i].GetComponent<TMP_InputField>().text);

            if (i == 0)
            {
                expHolderX = diff;
            }
            else
            {
                if (diff != expHolderX)
                {
                    expCheckX = false;
                    break;
                }
            }
        }
        //Give 1 mark for there being at list 3 axis labels per axis
        if(yAxisLabels.Count > 2)
        {
            marks += 1;

            //Give Y axis mark
            if (linearCheckY || expCheckY)
            {
                marks += 2;
            }
        }

        if(xAxisLabels.Count > 2)
        {
            marks += 1;

            //Give X axis mark
            if (linearCheckX || expCheckX)
            {
                marks += 2;
            }
        }
        mark += marks;
        gridLineLabelsLabel.text = marks + "/6";

    }

    void CheckEmptyFields()
    {
        int marks = 5;

        for(int i = 0; i < gradingTracker.allTableFields.Count; i++)
        {
            if(gradingTracker.allTableFields[i].text == "")
            {
                marks -= 1;
            }
        }

        if(marks <= 0)
        {
            marks = 0;
        }

        mark += marks;
        blankTableLabel.text = marks + "/5";
    }

    void SetTotal()
    {
        totalMark.text = mark + "/38";

        //Set Letter Grade Image
        if(mark >= 34)
        {
            gradeA.SetActive(true);
        }
        else if(mark >= 30 && mark < 34)
        {
            gradeB.SetActive(true);
        }
        else if (mark >= 26 && mark < 30)
        {
            gradeC.SetActive(true);
        }
        else if (mark >= 22 && mark < 26)
        {
            gradeD.SetActive(true);
        }
        else if (mark < 22)
        {
            gradeE.SetActive(true);
        }
    }
}
