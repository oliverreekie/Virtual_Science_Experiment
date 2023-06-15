using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CloseButtonController : MonoBehaviour
{
    //The button being pressed
    public Button theButton;

    public CanvasController canvasController;

    public ArrowController arrowController;

    public Text theText;

    //Variables entered in the info page
    public TMP_InputField independantField;
    public TMP_InputField dependantField;

    public AudioController audioController;

    void Start()
    {
        //Set up button listener
        theButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if(this.name == "Table Close Button")
        {
            canvasController.swapTableState();
            //If this is the first time being opened, stop the table arrow and start the graph arrow
            if (arrowController.graphHasOpened == false)
            {
                arrowController.arrowGraph.SetActive(true);
                arrowController.graphHasOpened = true;
                BuildState.Instance.buildState = "Graph";
                arrowController.tableInstructions.SetActive(false);
            }
            //Play paper rustle
            audioController.PickUpPaper();
        }
        else if(this.name == "Graph Close Button")
        {
            //If this is the first time being opened, stop the graph arrow and start the final arrow
            if (arrowController.graphInstructionsHasOpened == false)
            {
                arrowController.graphInstructions.SetActive(false);
                arrowController.graphInstructionsHasOpened = true;
                BuildState.Instance.buildState = "Final";
                arrowController.arrowFinal.SetActive(true);
            }

            canvasController.swapGraphState();
            //Play paper rustle
            audioController.PickUpPaper();
        }
        else if (this.name == "Final Close Button")
        {
            //If this is the first time being opened, stop the final arrow
            if (arrowController.finalHasOpened == false)
            {
                arrowController.finalHasOpened = true;
                BuildState.Instance.buildState = "Dropping";
                arrowController.arrowFinal.SetActive(false);
                arrowController.finalInstructions.SetActive(false);
            }
            canvasController.swapFinalState();
            //Play paper rustle
            audioController.PickUpPaper();
        }
        else if (this.name == "Info Close Button")
        {
            //Save the independent and dependent variables to buildstate
            BuildState.Instance.independentVariable = independantField.text;
            BuildState.Instance.dependentVariable = dependantField.text;

            canvasController.swapInfoState();
            //If this is the first time being opened, show the equation arrow
            if (arrowController.equationHasOpened == false)
            {
                arrowController.arrowEquation.SetActive(true);
                arrowController.equationHasOpened = true;
                BuildState.Instance.buildState = "Equation";
            }
            //Play paper rustle
            audioController.PickUpPaper();
        }
        else if (this.name == "Equation Close Button")
        {
            //If this is the first time being opened, show the build arrow
            canvasController.swapEquationState();
            if (arrowController.buildHasOpened == false)
            {
                arrowController.arrowBuild.SetActive(true);
                arrowController.buildHasOpened = true;
                BuildState.Instance.buildState = "Nothing";
            }
            //Play paper rustle
            audioController.PickUpPaper();
        }
        //Close the graph
        else if(this.name == "Open Graph Button")
        {
            canvasController.swapGraphState();
        }
        //Close the table
        else if (this.name == "Open Table Button")
        {
            canvasController.swapTableState();
        }
        //If drawing, stop drawing regression line. Else, start drawing line
        else if (this.name == "Draw Line Button")
        {
            if(canvasController.isDrawing == true)
            {
                canvasController.isDrawing = false;
                theText.text = "Start Drawing Line";
            }
            else
            {
                canvasController.isDrawing = true;
                theText.text = "Stop Drawing Line";
            }
        }
        //If showing the gradient lines, stop, else show it
        else if (this.name == "Gradient Line Button")
        {
            if (canvasController.isShowingGradient == true)
            {
                canvasController.isShowingGradient = false;
                theText.text = "Show";
            }
            else
            {
                canvasController.isShowingGradient = true;
                theText.text = "Hide";
            }
        }
        //Close settings page
        else if (this.name == "Settings Close Button")
        {
            canvasController.swapSettingsState();
        }
    }
}
