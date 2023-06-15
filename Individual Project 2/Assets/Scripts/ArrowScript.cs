using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using TMPro;

public class ArrowScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //Holds whether the user is currently holding the arror
    private bool isHolding = false;

    //The text that stores the current ruler value
    public TextMeshProUGUI distanceText;

    //Location of the arrow
    private double arrowLocation;

    //Pick up the arrow when the user clicks the mouse
    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
    }

    //Drop the arrow when the user releases the mouse
    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
    }

    private void Update()
    {
        //If the user is holding the arrow
        if(isHolding == true){
            //Convert world coordinates to ruler position
            arrowLocation = Math.Round((this.transform.position.x - 629.3) / 25.582);
            //Set text to show the arrow location
            distanceText.text = (arrowLocation.ToString() + "cm");

            //Checks if the arrow is past the ruler, if it is, return it to the ruler
            if(this.transform.position.x <= 629.3)
            {
                this.transform.position = new Vector3((float)629.6, this.transform.position.y, this.transform.position.z);
            }
            else if(this.transform.position.x >= 1908.4)
            {
                this.transform.position = new Vector3((float)1908.1, this.transform.position.y, this.transform.position.z);
            }
            else
            {
                this.transform.position = new Vector3(Input.mousePosition.x, this.transform.position.y, this.transform.position.z);
            }
        }
    }

    public double getArrowLocation()
    {
        return arrowLocation;
    }

}
