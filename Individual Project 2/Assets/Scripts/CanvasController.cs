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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            swapNotesState();
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            swapGraphState();
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
}
