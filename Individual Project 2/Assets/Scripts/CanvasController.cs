using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    //For each canvas, there is a reference to the canvas and a bool showing whether or not it is open
    public GameObject rulerCanvas;
    private bool rulerActive;

    public GameObject notesCanvas;
    private bool notesActive;

    public GameObject tableCanvas;
    private bool tableActive;

    public GameObject graphCanvas;
    private bool graphActive;

    public GameObject equationCanvas;
    private bool equationActive;

    public GameObject welcomeCanvas;
    private bool welcomeActive;

    public GameObject HUDCanvas;
    private bool HUDActive;

    public GameObject MenuCanvas;
    private bool MenuActive;

    public GameObject InfoCanvas;
    private bool InfoActive;

    public GameObject FinalCanvas;
    private bool FinalActive;

    public GameObject SettingsCanvas;
    private bool SettingsActive;

    //Open buttons for the graph and table
    public GameObject graphOpenButton;
    public GameObject tableOpenButton;

    //Is the user drawing a line of best fit
    public bool isDrawing = false;

    //Are the gradient lines showing
    public bool isShowingGradient = false;

    //Reference to gradient lines
    public GameObject gradientLines;

    void Start()
    {
        //Initially set all canvases except the welcome canvas to off
        rulerCanvas.SetActive(false);
        rulerActive = false;

        notesCanvas.SetActive(false);
        notesActive = false;

        tableCanvas.SetActive(false);
        tableActive = false;

        graphCanvas.SetActive(false);
        graphActive = false;

        equationCanvas.SetActive(false);
        equationActive = false;

        welcomeCanvas.SetActive(true);
        welcomeActive = true;

        HUDCanvas.SetActive(false);
        HUDActive = false;

        MenuCanvas.SetActive(false);
        MenuActive = false;

        InfoCanvas.SetActive(false);
        InfoActive = false;

        FinalCanvas.SetActive(false);
        FinalActive = false;

        SettingsCanvas.SetActive(false);
        SettingsActive = false;

        gradientLines.SetActive(false);
    }

    private void Update()
    {
        //Open and close notes when the user presses tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            swapNotesState();
        }
        //Open and close the menu when the user presses escape
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            swapMenuState();
        }
        //Functionality for graph close button
        if(graphCanvas.activeInHierarchy == true)
        {
            graphOpenButton.SetActive(false);
        }
        else
        {
            graphOpenButton.SetActive(true);
        }
        //Functionality for table close button
        if (tableCanvas.activeInHierarchy == true)
        {
            tableOpenButton.SetActive(false);
        }
        else
        {
            tableOpenButton.SetActive(true);
        }
        //Show gradient lines if required
        if(isShowingGradient == true)
        {
            gradientLines.SetActive(true);
        }
        else
        {
            gradientLines.SetActive(false);
        }
    }

    //Functions to turn each canvas on and off when called

    public void swapGraphState()
    {
        if(graphActive == false)
        {
            graphCanvas.SetActive(true);
            graphActive = true;
            BuildState.Instance.setGraphCanvasOpen(true);
        }
        else
        {
            graphCanvas.SetActive(false);
            graphActive = false;
            BuildState.Instance.setGraphCanvasOpen(false);
        }
    }

    public void swapRulerState()
    {
        if (rulerActive == false)
        {
            rulerCanvas.SetActive(true);
            rulerActive = true;
            BuildState.Instance.setRulerCanvasOpen(true);
        }
        else
        {
            rulerCanvas.SetActive(false);
            rulerActive = false;
            BuildState.Instance.setRulerCanvasOpen(false);
        }
    }
    public void swapNotesState()
    {
        if (notesActive == false)
        {
            notesCanvas.SetActive(true);
            notesActive = true;
            BuildState.Instance.setNotesCanvasOpen(true);
        }
        else
        {
            notesCanvas.SetActive(false);
            notesActive = false;
            BuildState.Instance.setNotesCanvasOpen(false);
        }
    }
    public void swapTableState()
    {
        if (tableActive == false)
        {
            tableCanvas.SetActive(true);
            tableActive = true;
            BuildState.Instance.setTableCanvasOpen(true);
        }
        else
        {
            tableCanvas.SetActive(false);
            tableActive = false;
            BuildState.Instance.setTableCanvasOpen(false);
        }
    }

    public void swapEquationState()
    {
        if (equationActive == false)
        {
            equationCanvas.SetActive(true);
            equationActive = true;
            BuildState.Instance.setEquationCanvasOpen(true);
        }
        else
        {
            equationCanvas.SetActive(false);
            equationActive = false;
            BuildState.Instance.setEquationCanvasOpen(false);
        }
    }

    public void swapWelcomeState()
    {
        if (welcomeActive == false)
        {
            welcomeCanvas.SetActive(true);
            welcomeActive = true;
            BuildState.Instance.setWelcomeCanvasOpen(true);
        }
        else
        {
            welcomeCanvas.SetActive(false);
            welcomeActive = false;
            BuildState.Instance.setWelcomeCanvasOpen(false);
        }
    }

    public void swapHUDState()
    {
        if (HUDActive == false)
        {
            HUDCanvas.SetActive(true);
            HUDActive = true;
            BuildState.Instance.setHUDCanvasOpen(true);
        }
        else
        {
            HUDCanvas.SetActive(false);
            HUDActive = false;
            BuildState.Instance.setHUDCanvasOpen(false);
        }
    }
    public void swapMenuState()
    {
        if (MenuActive == false)
        {
            MenuCanvas.SetActive(true);
            MenuActive = true;
            BuildState.Instance.setMenuCanvasOpen(true);
        }
        else
        {
            MenuCanvas.SetActive(false);
            MenuActive = false;
            BuildState.Instance.setMenuCanvasOpen(false);
        }
    }
    public void swapInfoState()
    {
        if (InfoActive == false)
        {
            InfoCanvas.SetActive(true);
            InfoActive = true;
            BuildState.Instance.setInfoCanvasOpen(true);
        }
        else
        {
            InfoCanvas.SetActive(false);
            InfoActive = false;
            BuildState.Instance.setInfoCanvasOpen(false);
        }
    }
    public void swapFinalState()
    {
        if (FinalActive == false)
        {
            FinalCanvas.SetActive(true);
            FinalActive = true;
            BuildState.Instance.setFinalCanvasOpen(true);
        }
        else
        {
            FinalCanvas.SetActive(false);
            FinalActive = false;
            BuildState.Instance.setFinalCanvasOpen(false);
        }
    }
    public void swapSettingsState()
    {
        if (SettingsActive == false)
        {
            SettingsCanvas.SetActive(true);
            SettingsActive = true;
            BuildState.Instance.setSettingsCanvasOpen(true);
        }
        else
        {
            SettingsCanvas.SetActive(false);
            SettingsActive = false;
            BuildState.Instance.setSettingsCanvasOpen(false);
        }
    }

    //Getters for whether each canvas is open or not
    public bool getRulerActive()
    {
        return rulerActive;
    }
    public bool getNotesActive()
    {
        return notesActive;
    }
    public bool getTableActive()
    {
        return tableActive;
    }
    public bool getGraphActive()
    {
        return graphActive;
    }
    public bool getEquationActive()
    {
        return equationActive;
    }
    public bool getWelcomeActive()
    {
        return welcomeActive;
    }
    public bool getHUDActive()
    {
        return HUDActive;
    }
    public bool getMenuActive()
    {
        return MenuActive;
    }
    public bool getInfoActive()
    {
        return InfoActive;
    }
    public bool getFinalActive()
    {
        return FinalActive;
    }
    public bool getSettingsActive()
    {
        return SettingsActive;
    }
}
