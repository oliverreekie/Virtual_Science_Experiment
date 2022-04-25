using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipButtonScript : MonoBehaviour
{
    public CanvasController canvasController;

    public WelcomeCanvasController welcomeCanvasController;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        if(this.name == "Skip Button")
        {
            canvasController.swapWelcomeState();
            canvasController.swapHUDState();
            welcomeCanvasController.stageNumber = 1;
        }
        else if(this.name == "Right Arrow")
        {
            welcomeCanvasController.stageNumber += 1;
            if(welcomeCanvasController.stageNumber == 5)
            {
                canvasController.swapWelcomeState();
                canvasController.swapHUDState();
                welcomeCanvasController.stageNumber = 1;
            }
        }
        else if (this.name == "Left Arrow")
        {
            welcomeCanvasController.stageNumber -= 1;
            if (welcomeCanvasController.stageNumber == 1)
            {
                welcomeCanvasController.stageNumber = 1;
            }
        }
    }
}
