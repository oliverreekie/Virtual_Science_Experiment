using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    //The greyscale determination of g image
    public GameObject grey;

    //The coloured determination of g image
    public GameObject colour;

    //Whether determination of g has been selected
    private bool determinationGActive;

    //Locators for determination of g box
    public GameObject topRight;
    public GameObject bottomLeft;

    //Explanation image for determination of g
    public GameObject explanation;

    //Initially only show greyscale image
    void Start()
    {
        colour.SetActive(false);
        determinationGActive = false;
        explanation.SetActive(false);
    }

    void Update()
    {
        if (determinationGActive == false)
        {
            //If hovering over determination of g show coloured image
            if (Input.mousePosition.x <= topRight.transform.position.x && Input.mousePosition.x >= bottomLeft.transform.position.x)
            {
                if (Input.mousePosition.y <= topRight.transform.position.y && Input.mousePosition.y >= bottomLeft.transform.position.y)
                {
                    colour.SetActive(true);
                }
                else
                {
                    colour.SetActive(false);
                }
            }
            else
            {
                colour.SetActive(false);
            }
        }

        //Show explanation when determination of g is active
        if(determinationGActive == true)
        {
            explanation.SetActive(true);
        }
        else
        {
            explanation.SetActive(false);
        }
    }

    public void SetDeterminationGActive(bool b)
    {
        determinationGActive = b;
    }

    public bool GetDeterminationGActive()
    {
        return determinationGActive;
    }
}
