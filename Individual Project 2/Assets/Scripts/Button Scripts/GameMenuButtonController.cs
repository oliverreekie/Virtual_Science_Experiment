using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuButtonController : MonoBehaviour
{
    public CanvasController canvasController;

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
        if (this.name == "Continue")
        {
            canvasController.swapMenuState();
        }
        else if (this.name == "Tutorial")
        {
            canvasController.swapWelcomeState();
            canvasController.swapMenuState();
            canvasController.swapHUDState();
        }
        else if (this.name == "Settings")
        {

        }
        else if (this.name == "Quit Game")
        {
            Application.Quit();
        }
    }
}
