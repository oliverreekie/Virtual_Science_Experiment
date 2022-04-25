using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class EquationMover : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isHolding = false;

    private double arrowLocation;

    public int whichLetter;

    private bool canHold = true;

    public Image box;

    public EquationController equation;

    public GameObject theBox;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(canHold == true)
        {
            isHolding = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;


        float distance = Vector3.Distance(this.transform.position, theBox.transform.position);
        print(distance);
        if(distance <= 25)
        {
            this.transform.position = new Vector3(theBox.transform.position.x, theBox.transform.position.y, theBox.transform.position.z);
            canHold = false;

            box.color = new Color32(0, 161, 65, 255);

            if(this.name == "v")
            {
               equation.setVComplete(true);
            }
            else if(this.name == "u")
            {
                equation.setUComplete(true);
            }
            else if (this.name == "s")
            {
                equation.setSComplete(true);
            }
            else if (this.name == "a")
            {
                equation.setAComplete(true);
            }
        }
    }

    private void Update()
    {
        if (isHolding == true)
        {
            if (this.transform.position.x <= 143)
            {
                this.transform.position = new Vector3((float)143.5, Input.mousePosition.y, this.transform.position.z);
            }
            else if (this.transform.position.x >= 2371)
            {
                this.transform.position = new Vector3((float)2370.5, Input.mousePosition.y, this.transform.position.z);
            }

            else if (this.transform.position.y >= 1292)
            {
                this.transform.position = new Vector3(Input.mousePosition.x, (float)1291.5, this.transform.position.z);
            }
            else if (this.transform.position.y <= 160)
            {
                this.transform.position = new Vector3(Input.mousePosition.x, (float)160.5, this.transform.position.z);
            }
            else
            {
                this.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z);
            }
        }

    }

    public double getArrowLocation()
    {
        return arrowLocation;
    }

}
