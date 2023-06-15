using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public MenuController menuController;

    // Start is called before the first frame update
    void Start()
    {
        //Set up button listener
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        //If the user selects the practical, change image from greyscale to colour
        if(this.name == "G_Colour")
        {
            menuController.SetDeterminationGActive(true);
            menuController.colour.SetActive(true);

        }
        //If the user clicks start experiment, having clicked on the experiment, play experiment scene
        else if(this.name == "Start Experiment")
        {
            if(menuController.GetDeterminationGActive() == true)
            {
                SceneManager.LoadScene(sceneName: "Determination_of_g_scene");
            }
        }
        //If the user clicks quit, close the game
        else if (this.name == "Quit Game")
        {
            Application.Quit();
        }

    }
}
