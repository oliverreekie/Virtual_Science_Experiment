using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class contains code reused from (Jimmy Vegas, 2018)
//This reused code is found on the lines
//46-48, 177-178, 191-192

public class PickUp : MonoBehaviour
{
    //The location that the user held item is suspended
    public Transform toHoldPoint;

    //The next apparatus stage to be instantiated
    public GameObject toInstantiate;

    public CanvasController canvasController;

    public ArrowController arrowController;

    public AudioController audioController;

    private void OnMouseDown()
    {
        //Distance between object and holdpoint
        float dist = Vector3.Distance(GetComponent<Rigidbody>().position, GameObject.Find("HoldPoint").transform.position);

        string name = GetComponent<Rigidbody>().name;

        //If the canvases are closed
        if (canvasController.getFinalActive() == false && canvasController.getTableActive() == false && 
            canvasController.getGraphActive() == false && canvasController.getInfoActive()== false && 
            canvasController.getEquationActive() == false && canvasController.getNotesActive() == false && 
            canvasController.getSettingsActive() == false && canvasController.getMenuActive() == false)
        {
            //If the object is less than four units away
            if (dist <= 4)
            {
                //If item is able to be picked up
                if (GetComponent<Rigidbody>().name != "ClampStand_LGOFF" && GetComponent<Rigidbody>().name != "Ruler, Clamp, LGOFF" && GetComponent<Rigidbody>().name != "Ruler, Clamp, LGOFF, Timer"
                    && GetComponent<Rigidbody>().name != "Ruler, Clamp, LGON, Timer, Wires" && GetComponent<Rigidbody>().name != "Clipboard" && GetComponent<Rigidbody>().name != "Info Page"
                    && GetComponent<Rigidbody>().name != "Graph Page" && GetComponent<Rigidbody>().name != "Equation Page" && GetComponent<Rigidbody>().name != "Final Page")
                {
                    //Reused Lines from (Jimmy Vegas, 2018)
                    //Pick up component and deactivate gravity
                    GetComponent<Rigidbody>().useGravity = false;
                    this.transform.position = toHoldPoint.position;
                    this.transform.parent = GameObject.Find("HoldPoint").transform;

                    //Hold references to what is being held
                    HoldPointScript.Instance.setIsHolding(true);
                    HoldPointScript.Instance.setObjHolding(GetComponent<Rigidbody>().name);
                }
                else if (HoldPointScript.Instance.getLookingAt() == "Clipboard")
                {
                    //Open table and close table arrow
                    arrowController.arrowTable.SetActive(false);
                    canvasController.swapTableState();
                    audioController.PickUpPaper();
                }
                else if (HoldPointScript.Instance.getLookingAt() == "Info Page")
                {
                    //Open info page and close info arrow
                    arrowController.arrowInfo.SetActive(false);
                    canvasController.swapInfoState();
                    audioController.PickUpPaper();
                }
                else if (HoldPointScript.Instance.getLookingAt() == "Final Page")
                {
                    //Open final page and close final arrow
                    arrowController.arrowFinal.SetActive(false);
                    canvasController.swapFinalState();
                    audioController.PickUpPaper();
                }
                else if (HoldPointScript.Instance.getLookingAt() == "Graph Page")
                {
                    //Open graph page and close graph arrow
                    arrowController.arrowGraph.SetActive(false);
                    canvasController.swapGraphState();
                    audioController.PickUpPaper();
                }
                else if (HoldPointScript.Instance.getLookingAt() == "Equation Page")
                {
                    //Open equation page and close equation arrow
                    arrowController.arrowEquation.SetActive(false);
                    canvasController.swapEquationState();
                    audioController.PickUpPaper();
                }
            }
        }
        
    }

    private void OnMouseUp()
    {
        //If looking at the build area
        if (HoldPointScript.Instance.getLookingAt() == "Build")
        {
            this.transform.parent = null;

            GetComponent<Rigidbody>().useGravity = true;

            HoldPointScript.Instance.setIsHolding(false);
            
            //If holding clampstand
            if (BuildState.Instance.getBuildState() == "Nothing" && HoldPointScript.Instance.getObHolding() == "ClampStand")
            {
                //Move clampstand to correct position and rotation
                this.transform.position = new Vector3((float)-5.057, (float)2.216, (float)5.218);
                this.transform.rotation = new Quaternion(0, -180, 0, 0);
                //Record new build state
                BuildState.Instance.setBuildState("ClampStand");

                //Remove build arrow
                if(arrowController.buildHasOpened == true)
                {
                    arrowController.arrowBuild.SetActive(false);
                }
                //Play click sound
                audioController.AttachClick();
            }
            //For each stage, if the player is holding the correct object, delete the object and apparatus and transform next apparatus stage to the correct location. Play audio click
            else if (BuildState.Instance.getBuildState() == "ClampStand" && HoldPointScript.Instance.getObHolding() == "LightGate_Off")
            {
                BuildState.Instance.setBuildState("ClampStand, LGOff");
                Destroy(gameObject);

                toInstantiate.transform.position = new Vector3((float)-5.052, (float)2.208, (float)5.226);

                audioController.AttachClick();

            }
            else if (BuildState.Instance.getBuildState() == "ClampStand, LGOff" && HoldPointScript.Instance.getObHolding() == "Ruler")
            {
                BuildState.Instance.setBuildState("Ruler, Clamp, LGOFF");
                Destroy(gameObject);

                toInstantiate.transform.position = new Vector3((float)-5.063, (float)2.207, (float)4.229);

                audioController.AttachClick();

            }
            else if (BuildState.Instance.getBuildState() == "Ruler, Clamp, LGOFF" && HoldPointScript.Instance.getObHolding() == "Timer")
            {
                BuildState.Instance.setBuildState("Ruler, Clamp, LGOFF, Timer");
                Destroy(gameObject);

                toInstantiate.transform.position = new Vector3((float)-5.06, (float)2.206, (float)4.224);

                audioController.AttachClick();
            }
            else if (BuildState.Instance.getBuildState() == "Ruler, Clamp, LGOFF, Timer" && HoldPointScript.Instance.getObHolding() == "Wires")
            {
                BuildState.Instance.setBuildState("Ruler, Clamp, LGOFF, Timer, Wires");
                Destroy(gameObject);

                toInstantiate.transform.position = new Vector3((float)-5.06, (float)2.206, (float)4.224);

                audioController.AttachClick();

                if (arrowController.tableHasOpened == false)
                {
                    arrowController.arrowTable.SetActive(true);
                    BuildState.Instance.buildState = "Table";
                }
            }
        }
        //If player drops the weighted card in the right location, open the ruler state
        else if (HoldPointScript.Instance.getLookingAt() == "Ruler, Clamp, LGON, Timer, Wires" && HoldPointScript.Instance.getObHolding() == "Weighted Card")
        {
            canvasController.swapRulerState();
        }
        else
        {
            //Reused Lines from (Jimmy Vegas, 2018)
            //Otherwise drop object
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;

            //Remove reference to what is being held
            HoldPointScript.Instance.setIsHolding(false);
        }

    }

    //If card is dropped from ruler
    public void droppingCardFromRuler()
    {
        //Reused Lines from (Jimmy Vegas, 2018)
        //Activate gravity
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;

        //Remove reference to what is being held
        HoldPointScript.Instance.setIsHolding(false);

        //Play whoosh sound
        audioController.StartWhoosh();
    }
}
