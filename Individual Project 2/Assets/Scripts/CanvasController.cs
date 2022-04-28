using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
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

    public GameObject graphOpenButton;

    public GameObject tableOpenButton;

    public bool isDrawing = false;

    public bool isShowingGradient = false;

    public GameObject gradientLines;

    void Start()
    {
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

        gradientLines.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            swapNotesState();
        }
/*        else if (Input.GetKeyDown(KeyCode.G))
        {
            swapGraphState();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            swapEquationState();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            swapWelcomeState();
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            swapInfoState();
        }*/
        else if (Input.GetKeyDown(KeyCode.F))
        {
            swapFinalState();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            swapMenuState();
        }

        if(graphCanvas.activeInHierarchy == true)
        {
            graphOpenButton.SetActive(false);
        }
        else
        {
            graphOpenButton.SetActive(true);
        }

        if (tableCanvas.activeInHierarchy == true)
        {
            tableOpenButton.SetActive(false);
        }
        else
        {
            tableOpenButton.SetActive(true);
        }

        if(isShowingGradient == true)
        {
            gradientLines.SetActive(true);
        }
        else
        {
            gradientLines.SetActive(false);
        }
    }

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
}
