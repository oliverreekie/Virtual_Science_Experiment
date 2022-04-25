using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildState : MonoBehaviour
{
    public static BuildState Instance { get; private set; }

    private string buildState = "Nothing";

    public GameObject clampStand;

    public GameObject clampStandLGOFF;

    public GameObject clampStandLGOFFRuler;

    public GameObject clampStandLGOFFRulerTimer;

    public GameObject buildCheck;

    private bool rulerCanvasOpen = false;

    private bool notesCanvasOpen = false;

    private bool tableCanvasOpen = false;

    private bool graphCanvasOpen = false;

    private bool equationCanvasOpen = false;

    private bool welcomeCanvasOpen = true;

    private bool HUDCanvasOpen = true;

    private bool MenuCanvasOpen = false;

    public TextMeshProUGUI currentGoalLabel;

    private void Awake()
    {
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
        if(buildState == "Nothing")
        {
            currentGoalLabel.text = "Add the clampstand";
        }
        if (buildState == "ClampStand")
        {
            currentGoalLabel.text = "Add the light gate";
        }
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
        if (buildState == "Ruler, Clamp, LGOFF, Timer, Wires")
        {
            Destroy(clampStandLGOFFRulerTimer);
            Destroy(buildCheck);
        }
    }

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
}
