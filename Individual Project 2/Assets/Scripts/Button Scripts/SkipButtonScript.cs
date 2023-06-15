using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipButtonScript : MonoBehaviour
{
    public CanvasController canvasController;

    public WelcomeCanvasController welcomeCanvasController;

    public ArrowController arrowController;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    //Called when the button is pressed
    void TaskOnClick()
    {
        //Calls function depending on the button name pressed
        if(this.name == "Skip Button")
        {
            //Finish and close the tutorial
            canvasController.swapWelcomeState();
            canvasController.swapHUDState();
            welcomeCanvasController.stageNumber = 1;

            //If this is the first time the tutorial has ended, show bouncing arrows to guide the user
            if (arrowController.infoHasOpened == false)
            {
                arrowController.arrowInfo.SetActive(true);
                arrowController.infoHasOpened = true;
            }
        }
        else if(this.name == "Right Arrow")
        {
            //Move to next stage of tutorial
            welcomeCanvasController.stageNumber += 1;
            if(welcomeCanvasController.stageNumber == 6)
            {
                canvasController.swapWelcomeState();
                canvasController.swapHUDState();
                welcomeCanvasController.stageNumber = 1;
                //If this is the first time the tutorial has ended, show bouncing arrows to guide the user
                if (arrowController.infoHasOpened == false)
                {
                    arrowController.arrowInfo.SetActive(true);
                    arrowController.infoHasOpened = true;
                }
            }
        }
        else if (this.name == "Left Arrow")
        {
            //Move to previous stage of tutorial
            welcomeCanvasController.stageNumber -= 1;
            if (welcomeCanvasController.stageNumber == 1)
            {
                welcomeCanvasController.stageNumber = 1;
            }
        }
    }
}
