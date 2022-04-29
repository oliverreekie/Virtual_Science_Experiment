using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CloseButtonController : MonoBehaviour
{
    public Button theButton;

    public CanvasController canvasController;

    public ArrowController arrowController;

    public Text theText;

    public TMP_InputField independantField;
    public TMP_InputField dependantField;

    void Start()
    {
        theButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if(this.name == "Table Close Button")
        {
            canvasController.swapTableState();
            if (arrowController.graphHasOpened == false)
            {
                arrowController.arrowGraph.SetActive(true);
                arrowController.graphHasOpened = true;
                BuildState.Instance.buildState = "Graph";
                arrowController.tableInstructions.SetActive(false);
            }
        }
        else if(this.name == "Graph Close Button")
        {
            if (arrowController.graphInstructionsHasOpened == false)
            {
                arrowController.graphInstructions.SetActive(false);
                arrowController.graphInstructionsHasOpened = true;
                BuildState.Instance.buildState = "Final";
                arrowController.arrowFinal.SetActive(true);
            }

            canvasController.swapGraphState();
        }
        else if (this.name == "Final Close Button")
        {
            if(arrowController.finalHasOpened == false)
            {
                arrowController.finalHasOpened = true;
                BuildState.Instance.buildState = "Dropping";
                arrowController.arrowFinal.SetActive(false);
                arrowController.finalInstructions.SetActive(false);
            }
            canvasController.swapFinalState();
        }
        else if (this.name == "Info Close Button")
        {
            BuildState.Instance.independentVariable = independantField.text;
            BuildState.Instance.dependentVariable = dependantField.text;

            canvasController.swapInfoState();
            //BuildState.Instance.buildState = "Nothing";
            if (arrowController.equationHasOpened == false)
            {
                arrowController.arrowEquation.SetActive(true);
                arrowController.equationHasOpened = true;
                BuildState.Instance.buildState = "Equation";
            }
        }
        else if (this.name == "Equation Close Button")
        {
            canvasController.swapEquationState();
            if (arrowController.buildHasOpened == false)
            {
                arrowController.arrowBuild.SetActive(true);
                arrowController.buildHasOpened = true;
                BuildState.Instance.buildState = "Nothing";
            }
        }
        else if(this.name == "Open Graph Button")
        {
            canvasController.swapGraphState();
        }
        else if (this.name == "Open Table Button")
        {
            canvasController.swapTableState();
        }
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
    }
}
