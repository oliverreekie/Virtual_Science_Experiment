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
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        if(this.name == "G_Colour")
        {
            menuController.SetDeterminationGActive(true);
            menuController.colour.SetActive(true);

        }
        else if(this.name == "Start Experiment")
        {
            if(menuController.GetDeterminationGActive() == true)
            {
                SceneManager.LoadScene(sceneName: "Determination_of_g_scene");
            }
        }
        else if (this.name == "Quit Game")
        {
            Application.Quit();
        }

    }
}
