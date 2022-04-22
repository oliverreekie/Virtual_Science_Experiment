using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform toHoldPoint;

    public GameObject toInstantiate;

    public CanvasController canvasController;

    private void OnMouseDown()
    {
        float dist = Vector3.Distance(GetComponent<Rigidbody>().position, GameObject.Find("HoldPoint").transform.position);

        string name = GetComponent<Rigidbody>().name;

        if(dist <= 4)
        {
            if(GetComponent<Rigidbody>().name != "ClampStand_LGOFF" && GetComponent<Rigidbody>().name != "Ruler, Clamp, LGOFF" && GetComponent<Rigidbody>().name != "Ruler, Clamp, LGOFF, Timer" && GetComponent<Rigidbody>().name != "Ruler, Clamp, LGON, Timer, Wires" && GetComponent<Rigidbody>().name != "Clipboard")
            {
                GetComponent<Rigidbody>().useGravity = false;
                this.transform.position = toHoldPoint.position;
                this.transform.parent = GameObject.Find("HoldPoint").transform;

                HoldPointScript.Instance.setIsHolding(true);
                HoldPointScript.Instance.setObjHolding(GetComponent<Rigidbody>().name);
            }
            else if (HoldPointScript.Instance.getLookingAt() == "Clipboard")
            {
                canvasController.swapTableState();
                //print("Hit");
            }
        }
    }

    private void OnMouseUp()
    {
        if (HoldPointScript.Instance.getLookingAt() == "Build")
        {
            this.transform.parent = null;

            GetComponent<Rigidbody>().useGravity = true;

            HoldPointScript.Instance.setIsHolding(false);
            
            if (BuildState.Instance.getBuildState() == "Nothing" && HoldPointScript.Instance.getObHolding() == "ClampStand")
            {
                this.transform.position = new Vector3((float)-5.057, (float)2.216, (float)5.218);
                this.transform.rotation = new Quaternion(0, -180, 0, 0);
                BuildState.Instance.setBuildState("ClampStand");
            }
            else if (BuildState.Instance.getBuildState() == "ClampStand" && HoldPointScript.Instance.getObHolding() == "LightGate_Off")
            {
                BuildState.Instance.setBuildState("ClampStand, LGOff");
                Destroy(gameObject);

                toInstantiate.transform.position = new Vector3((float)-5.052, (float)2.208, (float)5.226);
                
            }
            else if (BuildState.Instance.getBuildState() == "ClampStand, LGOff" && HoldPointScript.Instance.getObHolding() == "Ruler")
            {
                BuildState.Instance.setBuildState("Ruler, Clamp, LGOFF");
                Destroy(gameObject);

                toInstantiate.transform.position = new Vector3((float)-5.063, (float)2.207, (float)4.229);
                
            }
            else if (BuildState.Instance.getBuildState() == "Ruler, Clamp, LGOFF" && HoldPointScript.Instance.getObHolding() == "Timer")
            {
                BuildState.Instance.setBuildState("Ruler, Clamp, LGOFF, Timer");
                Destroy(gameObject);

                toInstantiate.transform.position = new Vector3((float)-5.06, (float)2.206, (float)4.224); 
            }
            else if (BuildState.Instance.getBuildState() == "Ruler, Clamp, LGOFF, Timer" && HoldPointScript.Instance.getObHolding() == "Wires")
            {
                BuildState.Instance.setBuildState("Ruler, Clamp, LGOFF, Timer, Wires");
                Destroy(gameObject);

                toInstantiate.transform.position = new Vector3((float)-5.06, (float)2.206, (float)4.224);
            }
        }
        else if (HoldPointScript.Instance.getLookingAt() == "Ruler, Clamp, LGON, Timer, Wires" && HoldPointScript.Instance.getObHolding() == "Weighted Card")
        {
            canvasController.swapRulerState();
        }
        else
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;

            HoldPointScript.Instance.setIsHolding(false);
        }

    }

    public void droppingCardFromRuler()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;

        HoldPointScript.Instance.setIsHolding(false);
    }
}
