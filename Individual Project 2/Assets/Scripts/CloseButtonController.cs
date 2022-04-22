using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButtonController : MonoBehaviour
{
    public Button theButton;

    public CanvasController canvasController;

    void Start()
    {
        theButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if(this.name == "Table Close Button")
        {
            canvasController.swapTableState();
        }
        else if(this.name == "Graph Close Button")
        {
            canvasController.swapGraphState();
        }
        else if (this.name == "Equation Close Button")
        {
            canvasController.swapEquationState();
        }
    }
}
