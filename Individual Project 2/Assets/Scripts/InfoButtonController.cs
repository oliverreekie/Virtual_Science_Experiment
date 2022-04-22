using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoButtonController : MonoBehaviour
{

    public Button theButton;

    public CanvasController canvasController;

    // Start is called before the first frame update
    void Start()
    {
        theButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        canvasController.swapEquationState();
    }
}
