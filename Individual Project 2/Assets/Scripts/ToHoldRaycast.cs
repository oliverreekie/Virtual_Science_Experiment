using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToHoldRaycast : MonoBehaviour
{
    public Text uiText;

    public CanvasController rulerController;

    void Update()
    {
        if(rulerController.getTableActive() == false && rulerController.getGraphActive() == false &&
            rulerController.getEquationActive() == false && rulerController.getInfoActive() == false)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3))
            {
                if (HoldPointScript.Instance.getIsHolding() == true)
                {
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
                    else if (hit.collider.name == "Ruler, Clamp, LGON, Timer, Wires")
                    {
                        if (HoldPointScript.Instance.getObHolding() == "Weighted Card")
                        {
                            uiText.text = "Drop";
                            HoldPointScript.Instance.setLookingAt("Ruler, Clamp, LGON, Timer, Wires");
                        }

                    }
                    else
                    {
                        uiText.text = ("");
                        HoldPointScript.Instance.setLookingAt("Nothing");
                    }


                }
                else if (hit.collider.name == "Clipboard")
                {
                    uiText.text = "Open Table";
                    HoldPointScript.Instance.setLookingAt("Clipboard");
                }
                else if (hit.collider.name == "Info Page")
                {
                    uiText.text = "Open Info Page" +
                        "";
                    HoldPointScript.Instance.setLookingAt("Info Page");
                }
                else if (hit.collider.name == "Graph Page")
                {
                    uiText.text = "Open Graph";
                    HoldPointScript.Instance.setLookingAt("Graph Page");
                }
                else if (hit.collider.name == "Equation Page")
                {
                    uiText.text = "Open Equation Page";
                    HoldPointScript.Instance.setLookingAt("Equation Page");
                }
                else if (hit.collider.name != "BuildObjCheck" && hit.collider.name != "Ruler, Clamp, LGON, Timer, Wires" && hit.collider.name != "Ruler, Clamp, LGOFF, Timer" 
                    && hit.collider.name != "Ruler, Clamp, LGOFF" && hit.collider.name != "ClampStand,LGOFF")
                {
                    uiText.text = ("Pick up");
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
