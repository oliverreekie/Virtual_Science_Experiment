using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToHoldRaycast : MonoBehaviour
{
    public Text uiText;

    void Update()
    {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3))
            {
                if(HoldPointScript.Instance.getIsHolding() == true)
                {
                    if (hit.collider.name == "BuildObjCheck")
                    {
                        if( (BuildState.Instance.getBuildState() == "Nothing" && HoldPointScript.Instance.getObHolding() == "ClampStand") ||
                            (BuildState.Instance.getBuildState() == "ClampStand" && HoldPointScript.Instance.getObHolding() == "LightGate_Off") ||
                            (BuildState.Instance.getBuildState() == "ClampStand, LGOff" && HoldPointScript.Instance.getObHolding() == "Ruler") ||
                            (BuildState.Instance.getBuildState() == "Ruler, Clamp, LGOFF" && HoldPointScript.Instance.getObHolding() == "Timer") ||
                            (BuildState.Instance.getBuildState() == "Ruler, Clamp, LGOFF, Timer" && HoldPointScript.Instance.getObHolding() == "Wires") )
                        {
                            uiText.text = "Build";
                            HoldPointScript.Instance.setLookingAt("Build");
                        }
                    }
                    else if (hit.collider.name == "Ruler, Clamp, LGON, Timer, Wires")
                    {
                        if(HoldPointScript.Instance.getObHolding() == "Weighted Card"){
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
            else if (hit.collider.name != "BuildObjCheck" && hit.collider.name != "Ruler, Clamp, LGON, Timer, Wires")
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
}
