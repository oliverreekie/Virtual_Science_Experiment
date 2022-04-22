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

        if (whichLetter == 1)
        {
            if (Input.mousePosition.x <= 405 && Input.mousePosition.x > 324)
            {
                if (Input.mousePosition.y <= 327 && Input.mousePosition.y >= 231)
                {
                    this.transform.position = new Vector3(370, 275, this.transform.position.z);

                    canHold = false;

                    box.color = new Color32(0, 161, 65, 255);

                    equation.setVComplete(true);
                }
            }

        }
        else if (whichLetter == 2)
        {
            if (Input.mousePosition.x <= 861 && Input.mousePosition.x > 785)
            {
                if (Input.mousePosition.y <= 327 && Input.mousePosition.y >= 231)
                {
                    this.transform.position = new Vector3(823, 275, this.transform.position.z);

                    canHold = false;

                    box.color = new Color32(0, 161, 65, 255);

                    equation.setAComplete(true);
                }
            }
        }
        else if (whichLetter == 3)
        {
            if (Input.mousePosition.x <= 592 && Input.mousePosition.x > 513)
            {
                if (Input.mousePosition.y <= 327 && Input.mousePosition.y >= 231)
                {
                    this.transform.position = new Vector3(557, 275, this.transform.position.z);

                    canHold = false;

                    box.color = new Color32(0, 161, 65, 255);

                    equation.setSComplete(true);
                }
            }
        }
        else if (whichLetter == 4)
        {
            if (Input.mousePosition.x <= 703 && Input.mousePosition.x > 624)
            {
                if (Input.mousePosition.y <= 327 && Input.mousePosition.y >= 231)
                {
                    this.transform.position = new Vector3(680, 275, this.transform.position.z);

                    canHold = false;

                    box.color = new Color32(0, 161, 65, 255);

                    equation.setUComplete(true);
                }
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
