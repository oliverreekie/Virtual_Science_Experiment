using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class GradingSystem : MonoBehaviour
{
    //Whether the user has entered a gradient
    private bool hasPressedEnter;

    //Fields to hold the user input of the difference in y and x values
    public TMP_InputField xDifference;
    public TMP_InputField yDifference;

    //Enter and submit buttons
    public Button enterButton;
    public Button submitButton;

    //Label for each gradient
    public TextMeshProUGUI gradient1;
    public TextMeshProUGUI gradient2;

    //Holds stage 1 (before the user submits their work) and stage 2 (where the marks are given out)
    public GameObject stage1;
    public GameObject stage2;

    //Label for each mark to be awarded
    public TextMeshProUGUI independentLabel;
    public TextMeshProUGUI dependentLabel;
    public TextMeshProUGUI graphLabelsLabel;
    public TextMeshProUGUI tableUnitsLabel;
    public TextMeshProUGUI gravityLabel;
    public TextMeshProUGUI gridLineLabelsLabel;
    public TextMeshProUGUI blankTableLabel;
    public TextMeshProUGUI lineOfBestFitGradient;
    public TextMeshProUGUI totalMark;
    public TextMeshProUGUI timer;

    //Graph Axis Locators
    public Image axisMarkerBotttomLeft;
    public Image axisMarkerTopRight;
    public Image axisMarkerUnderGraph;

    public GradingTracker gradingTracker;

    //User entered gravity value
    private float gravityValue;

    //Overall mark awarded
    private int mark;

    //Grade Images
    public GameObject gradeA;
    public GameObject gradeB;
    public GameObject gradeC;
    public GameObject gradeD;
    public GameObject gradeE;

    public OverallTimerScript overallTimer;

    //Label to show error that no gradient has been entered when submitting
    public GameObject noGradientWarning;

    //Feedback section
    public GameObject fullMarks;
    public GameObject notFullMarks;
    public TextMeshProUGUI feedback;

    //Mark per section
    private int independentVariableMark = 0;
    private int dependentVariableMark = 0;
    private int graphLabelsMark = 0;
    private int tableUnitsMark = 0;
    private int gravityMark = 0;
    private int gridLineLabelsMark = 0;
    private int blankTableMark = 0;
    private int lineOfBestFitGradientMark = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Set up button listeners
        enterButton.onClick.AddListener(TaskOnClick);
        submitButton.onClick.AddListener(TaskOnClickSubmit);

        //Set initial stage states
        stage1.SetActive(true);
        stage2.SetActive(false);

        //Whether the user has pressed enter
        hasPressedEnter = false;

        //Initially all grade images are closed
        gradeA.SetActive(false);
        gradeB.SetActive(false);
        gradeC.SetActive(false);
        gradeD.SetActive(false);
        gradeE.SetActive(false);

        //To open if the user tries to submit without a gradient
        noGradientWarning.SetActive(false);

        //Set full marks labels to closed
        fullMarks.SetActive(false);
        notFullMarks.SetActive(false);
    }

    //When the user presses the enter button
    void TaskOnClick()
    {
        //If the inputfields are not empty
        if(xDifference.text != "" && yDifference.text != "")
        {
            float x = float.Parse(xDifference.text);
            float y = float.Parse(yDifference.text);

            //Calulate g from difference in y and x
            float g = x / y;

            gradient1.text = g.ToString();
            gradient2.text = g.ToString();

            gravityValue = g;

            hasPressedEnter = true;

            noGradientWarning.SetActive(false);
        }
        //Show warning that gravity value was entered incorrectly
        else
        {
            noGradientWarning.SetActive(true);
        }
    }

    //If the user presses the submit button
    void TaskOnClickSubmit()
    {
        //If gravity value has been submitted
        if(hasPressedEnter == true)
        {
            //Close stage 1 and open stage 2
            stage1.SetActive(false);
            stage2.SetActive(true);

            //Run marking functions
            CheckVariables();
            CheckGraphLabels();
            CheckGraphHeaders();
            CheckGravityValue();
            CheckGraphLineLabels();
            CheckEmptyFields();
            CheckLineGradient();
            SetTotal();

            //Show timer text on screen
            timer.text = overallTimer.timerValue;

            //If full marks display full marks screen
            if(mark == 43)
            {
                fullMarks.SetActive(true);
            }
            //Otherwise show feedback
            else
            {
                notFullMarks.SetActive(true);

                GiveFeedback();
            }
        }
    }

    //Checks that the independent and dependent variables were entered correctly
    private void CheckVariables()
    {
        //Checks variations of the same word to account for different ways of saying it
        if(BuildState.Instance.independentVariable.Contains("Distance") || 
            BuildState.Instance.independentVariable.Contains("distance") || 
            BuildState.Instance.independentVariable == "d" || 
            BuildState.Instance.independentVariable == "D" ||
            BuildState.Instance.independentVariable.Contains("(D)") ||
            BuildState.Instance.independentVariable.Contains("(d)"))
        {
            //Awards marks accordingly
            independentLabel.text = "5/5";
            independentVariableMark = 5;
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
            independentVariableMark = 3;
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
            dependentVariableMark = 5;
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
            dependentVariableMark = 3;
            mark += 3;
        }
        else
        {
            dependentLabel.text = "0/5";
        }
    }

    //Checks whether the graph was labelled correctly
    private void CheckGraphLabels()
    {
        //Keeps track of mark awarded so far
        int score = 0;
        int counter = 0;
        for(int i = 0; i < gradingTracker.graphLabels.Count; i++)
        {
            if(gradingTracker.graphLabels[i].transform.position.y >= axisMarkerTopRight.transform.position.y)
            {
                //If there is a title label, give two marks
                if(gradingTracker.graphLabels[i].GetComponent<InputField>().text != "")
                {
                    score += 2;
                    counter += 1;
                }
            }
            //Checks Y axis label
            else if (gradingTracker.graphLabels[i].transform.position.x <= axisMarkerBotttomLeft.transform.position.x)
            {
                //Checks with variations of the same word to account for different ways of saying it
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
            //Checks X axis label
            else if(gradingTracker.graphLabels[i].transform.position.y <= axisMarkerBotttomLeft.transform.position.y && gradingTracker.graphLabels[i].transform.position.y >= axisMarkerUnderGraph.transform.position.y)
            {
                //Checks with variations of the same word to account for different ways of saying it
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
            //Only checks the first three relevent fields
            if(counter >= 3)
            {
                break;
            }
          
        }
        //Awards mark accordingly
        mark += score;
        graphLabelsMark = score;
        graphLabelsLabel.text = score + "/6"; 
    }

    //Checks the table has correct units in header
    private void CheckGraphHeaders()
    {
        int unitMarks = 0;
        int count = 0;

        for(int i = 0; i < gradingTracker.graphHeaders.Count; i++)
        {
            //Awards marks for each relevent header
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

        //Gives marks accordingly
        mark += unitMarks / 2;
        tableUnitsLabel.text = (unitMarks / 2) + "/6";
        tableUnitsMark = unitMarks / 2;

    }

    //Compares calculated gravity value against real value
    private void CheckGravityValue()
    {
        //5 marks available, but 1 removed for every integer value discrepency in values
        if(gravityValue >= 9 && gravityValue <= 10)
        {
            gravityLabel.text = "5/5";
            mark += 5;
            gravityMark = 5;
        }
        else if((gravityValue >= 8 && gravityValue <= 9) || (gravityValue >= 10 && gravityValue <= 11))
        {
            gravityLabel.text = "4/5";
            mark += 4;
            gravityMark = 4;
        }
        else if ((gravityValue >= 7 && gravityValue <= 8) || (gravityValue >= 11 && gravityValue <= 12))
        {
            gravityLabel.text = "3/5";
            mark += 3;
            gravityMark = 3;
        }
        else if ((gravityValue >= 6 && gravityValue <= 7) || (gravityValue >= 12 && gravityValue <= 13))
        {
            gravityLabel.text = "2/5";
            mark += 2;
            gravityMark = 2;
        }
        else if ((gravityValue >= 5 && gravityValue <= 5) || (gravityValue >= 13 && gravityValue <= 14))
        {
            gravityLabel.text = "1/5";
            mark += 1;
            gravityMark = 1;
        }
        else
        {
            gravityLabel.text = "0/5";
        }
    }

    //Checks the graph lines are labelled with consistent scale
    private void CheckGraphLineLabels()
    {
        //Holds current mark awarded
        int marks = 0;

        //Create lists to be manipulated
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

        //Check if increasing linearly
        bool linearCheckX = true;
        float linearHolderX = 0;

        for (int i = 0; i < xAxisLabels.Count - 1; i++)
        {
            float diff = float.Parse(xAxisLabels[i + 1].GetComponent<TMP_InputField>().text) 
                - float.Parse(xAxisLabels[i].GetComponent<TMP_InputField>().text);

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
            float diff = float.Parse(yAxisLabels[i + 1].GetComponent<TMP_InputField>().text) 
                / float.Parse(yAxisLabels[i].GetComponent<TMP_InputField>().text);

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

        //Check if increasing exponentially
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

        //Award marks accordingly
        mark += marks;
        gridLineLabelsLabel.text = marks + "/6";
        gridLineLabelsMark = marks;

    }

    //Check the table does not contain empty fields
    private void CheckEmptyFields()
    {
        //Marks available
        int marks = 5;

        //Loop through all fields and remove a mark for every empty field
        for(int i = 0; i < gradingTracker.allTableFields.Count; i++)
        {
            if(gradingTracker.allTableFields[i].text == "")
            {
                marks -= 1;
            }
        }

        //Minimum marks are zero
        if(marks <= 0)
        {
            marks = 0;
        }

        //Award marks accordingly
        mark += marks;
        blankTableLabel.text = marks + "/5";
        blankTableMark = marks;
    }

    //Checks the line gradient against points provided
    private void CheckLineGradient()
    {
        //Create a new list
        List<GameObject> graphPointsOnGraph = new List<GameObject>();

        //Create a list of all the graph points that are currently on the graph
        for (int i = 0; i < gradingTracker.graphPoints.Count; i++)
        {
            if (gradingTracker.graphPoints[i] != null)
            {
                if (gradingTracker.graphPoints[i].transform.position.y >= axisMarkerBotttomLeft.transform.position.y)
                {
                    graphPointsOnGraph.Add(gradingTracker.graphPoints[i]);
                }
            }

        }
        //Variables to hold means
        double meanX = 0;
        double meanY = 0;

        //Variables to hold differences to sum
        double xAndYDifference = 0;
        double xSquared = 0;

        //Calculate mean of each coordinate
        for (int i = 0; i < graphPointsOnGraph.Count; i++)
        {
            meanX += graphPointsOnGraph[i].transform.position.x;
            meanY += graphPointsOnGraph[i].transform.position.y;
        }

        meanX = meanX / graphPointsOnGraph.Count;
        meanY = meanY / graphPointsOnGraph.Count;

        //Calculate components using the least squares method
        for (int i = 0; i < graphPointsOnGraph.Count; i++)
        {
            double xDiff = (graphPointsOnGraph[i].transform.position.x - meanX);
            double yDiff = (graphPointsOnGraph[i].transform.position.y - meanY);

            xAndYDifference += (xDiff * yDiff);
            xSquared += (xDiff * xDiff);
        }

        //Sum and average the values from the least squares method
        double gradientPrediction = xAndYDifference / xSquared;

        //Calculate percentage difference between user calculated gradient and perfect
        double gradientsDifference = (gradientPrediction / gradingTracker.calculatedGradient) * 100;

        //5 marks initially available. Remove 1 mark for every 10 percent discrepancy between user gradient and perfect gradient
        if (gradientsDifference <= 110 && gradientsDifference > 90)
        {
            lineOfBestFitGradientMark = 5;
        }
        else if ((gradientsDifference <= 120 && gradientsDifference > 110) || (gradientsDifference <= 90 && gradientsDifference > 80))
        {
            lineOfBestFitGradientMark = 4;

        }
        else if ((gradientsDifference <= 130 && gradientsDifference > 120) || (gradientsDifference <= 80 && gradientsDifference > 70))
        {
            lineOfBestFitGradientMark = 3;
        }
        else if ((gradientsDifference <= 140 && gradientsDifference > 130) || (gradientsDifference <= 70 && gradientsDifference > 60))
        {
            lineOfBestFitGradientMark = 2;
        }
        else if ((gradientsDifference <= 150 && gradientsDifference > 140) || (gradientsDifference <= 60 && gradientsDifference > 50))
        {
            lineOfBestFitGradientMark = 1;
        }
        else if (gradientsDifference > 150 || gradientsDifference < 50)
        {
            lineOfBestFitGradientMark = 0;
        }

        //Award marks accordingly
        lineOfBestFitGradient.text = lineOfBestFitGradientMark + "/5";
    }

    //Give letter grade based on mark
    private void SetTotal()
    {
        //Show the total mark to player
        totalMark.text = mark + "/43";

        //Set Letter Grade Image based on mark
        if(mark >= 35)
        {
            gradeA.SetActive(true);
        }
        else if(mark >= 31 && mark < 35)
        {
            gradeB.SetActive(true);
        }
        else if (mark >= 27 && mark < 31)
        {
            gradeC.SetActive(true);
        }
        else if (mark >= 23 && mark < 27)
        {
            gradeD.SetActive(true);
        }
        else if (mark < 23)
        {
            gradeE.SetActive(true);
        }
    }

    
    //Gives feedback to user
    private void GiveFeedback()
    {
        //For each point that is not full marks, append pre-written feedback to label
        if(independentVariableMark < 5 || dependentVariableMark < 5)
        {
            feedback.text += "- Read up on independent and dependent variables to understand what which are which \n";
        }
        if (graphLabelsMark < 5)
        {
            feedback.text += "- When creating the graph, remember to label each axis with the variable you are plotting as well as giving the graph a relevant title \n";
        }
        if (tableUnitsMark < 6)
        {
            feedback.text += "- In the table remember to plot the units in the headers \n";
        }
        if (gravityMark < 6)
        {
            feedback.text += "- To improve your value of g, repeat the experiment as unpredictable variables can impact your results \n";
        }
        if (gridLineLabelsMark < 6)
        {
            feedback.text += "- Remember to label your grid lines with a consistent scale on both axis' \n";
        }
        if (blankTableMark < 5)
        {
            feedback.text += "- Fill in all fields in the table \n";
        }
        if(lineOfBestFitGradientMark < 5)
        {
            feedback.text += "- Draw the line of best fit through all the graph points \n";
        }

    }
}
