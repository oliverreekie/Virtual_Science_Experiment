using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildState : MonoBehaviour
{
    //Sets class as singleton
    public static BuildState Instance { get; private set; }

    //Holds current state
    public string buildState = "Info";

    //Refernce to each apparatus stage
    public GameObject clampStand;
    public GameObject clampStandLGOFF;
    public GameObject clampStandLGOFFRuler;
    public GameObject clampStandLGOFFRulerTimer;
    public GameObject buildCheck;

    //Holds whether each canvas is open or closed
    private bool rulerCanvasOpen = false;
    private bool notesCanvasOpen = false;
    private bool tableCanvasOpen = false;
    private bool graphCanvasOpen = false;
    private bool equationCanvasOpen = false;
    private bool welcomeCanvasOpen = true;
    private bool HUDCanvasOpen = true;
    private bool MenuCanvasOpen = false;
    private bool InfoCanvasOpen = false;
    private bool FinalCanvasOpen = false;
    private bool SettingsCanvasOpen = false;

    //Instruction labels on HUD
    public TextMeshProUGUI currentGoalLabel;
    public TextMeshProUGUI mainGoalLabel;

    //Holding the variables entered by the user on the info page
    public string independentVariable;
    public string dependentVariable;

    private void Awake()
    {
        //Destroy secondary instances of class - for singleton implementation
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Update()
    {
        //For each stage, display relevent instructions on HUD
        if(buildState == "Info")
        {
            mainGoalLabel.text = "Plan the Experiment";
            currentGoalLabel.text = "Read the info sheet and fill in variables";
        }
        if (buildState == "Equation")
        {
            currentGoalLabel.text = "Read the equation sheet and solve the equations";
        }
        if (buildState == "Nothing")
        {
            mainGoalLabel.text = "Build the Apparatus";
            currentGoalLabel.text = "Add the clampstand";
        }
        if (buildState == "ClampStand")
        {
            currentGoalLabel.text = "Add the light gate";
        }
        //If the user adds a new apparatus element, delete current state
        if (buildState == "ClampStand, LGOff")
        {
            Destroy(clampStand);
            currentGoalLabel.text = "Add the ruler";
        }
        if (buildState == "Ruler, Clamp, LGOFF")
        {
            Destroy(clampStandLGOFF);
            currentGoalLabel.text = "Add the timer";
        }
        if (buildState == "Ruler, Clamp, LGOFF, Timer")
        {
            Destroy(clampStandLGOFFRuler);
            currentGoalLabel.text = "Add the wires";
        }
        if (buildState == "Table")
        {
            Destroy(clampStandLGOFFRulerTimer);
            Destroy(buildCheck);
            mainGoalLabel.text = "Check evaluation sheets";
            currentGoalLabel.text = "Read the table page";
        }
        if (buildState == "Graph")
        {
            mainGoalLabel.text = "Check evaluation sheets";
            currentGoalLabel.text = "Read the graph page";
        }
        if (buildState == "Final")
        {
            mainGoalLabel.text = "Check evaluation sheets";
            currentGoalLabel.text = "Check final page";
        }
        if (buildState == "Dropping")
        {
            mainGoalLabel.text = "Conduct Experiment";
            currentGoalLabel.text = "Systematically drop card through light gate and record values";
        }
    }

    //Getters and setters for each variable
    public void setBuildState(string s)
    {
        buildState = s;
    }

    public string getBuildState()
    {
        return buildState;
    }

    public void setRulerCanvasOpen(bool b)
    {
        rulerCanvasOpen = b;
    }

    public bool getRulerCanvasOpen()
    {
        return rulerCanvasOpen;
    }
    public void setNotesCanvasOpen(bool b)
    {
        notesCanvasOpen = b;
    }

    public bool getNotesCanvasOpen()
    {
        return notesCanvasOpen;
    }

    public void setTableCanvasOpen(bool b)
    {
        notesCanvasOpen = b;
    }

    public bool getTableCanvasOpen()
    {
        return notesCanvasOpen;
    }

    public void setGraphCanvasOpen(bool b)
    {
        graphCanvasOpen = b;
    }

    public bool getGraphCanvasOpen()
    {
        return graphCanvasOpen;
    }

    public void setEquationCanvasOpen(bool b)
    {
        equationCanvasOpen = b;
    }

    public bool getEquationCanvasOpen()
    {
        return equationCanvasOpen;
    }

    public void setWelcomeCanvasOpen(bool b)
    {
       welcomeCanvasOpen = b;
    }

    public bool getWelcomeCanvasOpen()
    {
        return welcomeCanvasOpen;
    }

    public void setHUDCanvasOpen(bool b)
    {
        HUDCanvasOpen = b;
    }

    public bool getHUDCanvasOpen()
    {
        return HUDCanvasOpen;
    }
    public void setMenuCanvasOpen(bool b)
    {
        MenuCanvasOpen = b;
    }

    public bool getMenuCanvasOpen()
    {
        return MenuCanvasOpen;
    }
    public void setInfoCanvasOpen(bool b)
    {
        InfoCanvasOpen = b;
    }

    public bool getInfoCanvasOpen()
    {
        return InfoCanvasOpen;
    }
    public void setFinalCanvasOpen(bool b)
    {
        FinalCanvasOpen = b;
    }

    public bool getFinalCanvasOpen()
    {
        return FinalCanvasOpen;
    }
    public void setSettingsCanvasOpen(bool b)
    {
        SettingsCanvasOpen = b;
    }

    public bool getSettingsCanvasOpen()
    {
        return SettingsCanvasOpen;
    }
}
