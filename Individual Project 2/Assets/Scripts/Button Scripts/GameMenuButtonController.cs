using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenuButtonController : MonoBehaviour
{
    public CanvasController canvasController;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    //Called when the button is clicked
    void TaskOnClick()
    {
        //Checks what button is pressed by accessing the button name
        if (this.name == "Continue")
        {
            //Turns off the menu
            canvasController.swapMenuState();
        }
        else if (this.name == "Tutorial")
        {
            //Begins tutorial again
            canvasController.swapWelcomeState();
            canvasController.swapMenuState();
            canvasController.swapHUDState();
        }
        else if (this.name == "Settings")
        {
            //Opens setting screen
            canvasController.swapSettingsState();
        }
        else if (this.name == "Quit Game")
        {
            //Reloads the main menu scene
            SceneManager.LoadScene(sceneName: "Main_Menu_Scene");
        }
    }
}
