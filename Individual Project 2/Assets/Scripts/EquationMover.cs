using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class EquationMover : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //Whether the user is holding the component
    private bool isHolding = false;

    //Location of component
    private double arrowLocation;

    //Which component is being held
    public int whichLetter;

    //If the component has been placed yet
    private bool canHold = true;

    //The component game object
    public Image box;

    public EquationController equation;

    //The box where the equation must be moved to
    public GameObject theBox;

    //Pick up component on mouse down if the component has not been successfully placed yet
    public void OnPointerDown(PointerEventData eventData)
    {
        if(canHold == true)
        {
            isHolding = true;
        }
    }

    //Release component on mouse up
    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;

        //If within the correct box, freeze position and record as in the correct place
        float distance = Vector3.Distance(this.transform.position, theBox.transform.position);
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

    //Move to mouse position if holding component. Maximum and minimums stop component from moving off the page
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
