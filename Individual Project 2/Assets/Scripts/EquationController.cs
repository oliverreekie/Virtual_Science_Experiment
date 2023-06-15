using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquationController : MonoBehaviour
{
    //Each suvat equation image
    public GameObject equation1;
    public GameObject equation2;
    public GameObject equation3;
    public GameObject equation4;
    public GameObject equation5;
    public GameObject green;

    //Whether the user has selected the correct equation
    private bool ifCorrect = false;

    //Stage 2 of the page
    public GameObject stage2;

    //Whether each component has been rearranged successfully yet
    private bool vComplete = false;
    private bool uComplete = false;
    private bool aComplete = false;
    private bool sComplete = false;

    public GameObject finalText;

    public GameObject closeButton;

    void Start()
    {
        //Set all suvat equations to invisible initially
        equation1.SetActive(false);
        equation2.SetActive(false);
        equation3.SetActive(false);
        equation4.SetActive(false);
        equation5.SetActive(false);
        green.SetActive(false);
        stage2.SetActive(false);
        finalText.SetActive(false);
        closeButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //If the user selects the correct answer, show all equation marks
        if(ifCorrect == true)
        {
            equation1.SetActive(true);
            equation2.SetActive(true);
            equation3.SetActive(true);
            equation4.SetActive(true);
            equation5.SetActive(true);
            green.SetActive(true);
            stage2.SetActive(true);

        }

        if(getAreAllComplete() == true)
        {
            finalText.SetActive(true);
            closeButton.SetActive(true);
        }
    }
    //Set components as active when successfully rearranged
    public void setVComplete(bool v)
    {
        vComplete = v;
    }
    public void setUComplete(bool v)
    {
        uComplete = v;
    }
    public void setAComplete(bool v)
    {
        aComplete = v;
    }
    public void setSComplete(bool v)
    {
        sComplete = v;
    }

    public bool getAreAllComplete()
    {
        if (vComplete == true && uComplete == true && aComplete == true && sComplete == true)
        {
            return true;
        }
        else return false;
    }

    public void setIfCorrect(bool b)
    {
        ifCorrect = b;
    }
}
