using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToHoldRaycast : MonoBehaviour
{
    //HUD text in the center of the screen
    public Text uiText;

    public CanvasController rulerController;

    void Update()
    {
        //If the canvases are not open
        if(rulerController.getTableActive() == false && rulerController.getGraphActive() == false &&
            rulerController.getEquationActive() == false && rulerController.getInfoActive() == false)
        {
            //Fire raycast
            RaycastHit hit;

            //If raycast hits an object
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3))
            {
                if (HoldPointScript.Instance.getIsHolding() == true)
                {
                    //Show build if looking at the build area
                    if (hit.collider.name == "BuildObjCheck")
                    {
                        if ((BuildState.Instance.getBuildState() == "Nothing" && HoldPointScript.Instance.getObHolding() == "ClampStand") ||
                            (BuildState.Instance.getBuildState() == "ClampStand" && HoldPointScript.Instance.getObHolding() == "LightGate_Off") ||
                            (BuildState.Instance.getBuildState() == "ClampStand, LGOff" && HoldPointScript.Instance.getObHolding() == "Ruler") ||
                            (BuildState.Instance.getBuildState() == "Ruler, Clamp, LGOFF" && HoldPointScript.Instance.getObHolding() == "Timer") ||
                            (BuildState.Instance.getBuildState() == "Ruler, Clamp, LGOFF, Timer" && HoldPointScript.Instance.getObHolding() == "Wires"))
                        {
                            uiText.text = "Build";
                            HoldPointScript.Instance.setLookingAt("Build");
                        }
                    }
                    //If holding card and looking at the appararus, show drop
                    else if (hit.collider.name == "Ruler, Clamp, LGON, Timer, Wires")
                    {
                        if (HoldPointScript.Instance.getObHolding() == "Weighted Card")
                        {
                            uiText.text = "Drop";
                            HoldPointScript.Instance.setLookingAt("Ruler, Clamp, LGON, Timer, Wires");
                        }

                    }
                    //Otherwise show nothing
                    else
                    {
                        uiText.text = ("");
                        HoldPointScript.Instance.setLookingAt("Nothing");
                    }


                }
                //Show open table when looking at the table
                else if (hit.collider.name == "Clipboard")
                {
                    uiText.text = "Open Table";
                    //Hold reference to what is being looked at
                    HoldPointScript.Instance.setLookingAt("Clipboard");
                }
                //Show open info page when looking at the info page
                else if (hit.collider.name == "Info Page")
                {
                    uiText.text = "Open Info Page" +
                        "";
                    //Hold reference to what is being looked at
                    HoldPointScript.Instance.setLookingAt("Info Page");
                }
                //Show open graph page when looking at the graph page
                else if (hit.collider.name == "Graph Page")
                {
                    uiText.text = "Open Graph";
                    //Hold reference to what is being looked at
                    HoldPointScript.Instance.setLookingAt("Graph Page");
                }
                //Show open final page when looking at the final page
                else if (hit.collider.name == "Final Page")
                {
                    uiText.text = "Open Final Page";
                    //Hold reference to what is being looked at
                    HoldPointScript.Instance.setLookingAt("Final Page");
                }
                //Show open equation page when looking at the equation page
                else if (hit.collider.name == "Equation Page")
                {
                    uiText.text = "Open Equation Page";
                    //Hold reference to what is being looked at
                    HoldPointScript.Instance.setLookingAt("Equation Page");
                }
                //Otherwise show pick up
                else if (hit.collider.name != "BuildObjCheck" && hit.collider.name != "Ruler, Clamp, LGON, Timer, Wires" && hit.collider.name != "Ruler, Clamp, LGOFF, Timer" 
                    && hit.collider.name != "Ruler, Clamp, LGOFF" && hit.collider.name != "ClampStand,LGOFF")
                {
                    uiText.text = ("Pick up");
                    //Hold reference to what is being looked at
                    HoldPointScript.Instance.setLookingAt("Object");
                }
            }
            else
            {
                uiText.text = "";
                HoldPointScript.Instance.setLookingAt("Nothing");
            }
        }
        else
        {
            HoldPointScript.Instance.setLookingAt("");
        }
        

    }
}
