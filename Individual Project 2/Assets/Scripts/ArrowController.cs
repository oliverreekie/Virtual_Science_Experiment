using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    //Reference to each of the bouncing arrow objects
    public GameObject arrowInfo;
    public GameObject arrowEquation;
    public GameObject arrowBuild;
    public GameObject arrowTable;
    public GameObject arrowGraph;
    public GameObject arrowFinal;

    //Referenec to the instruction stage of each page
    public GameObject tableInstructions;
    public GameObject graphInstructions;
    public GameObject finalInstructions;

    //Holds whether each page has been opened for the first time yet
    public bool infoHasOpened = false;
    public bool equationHasOpened = false;
    public bool buildHasOpened = false;
    public bool tableHasOpened = false;
    public bool graphHasOpened = false;
    public bool finalHasOpened = false;
    public bool graphInstructionsHasOpened = false;
    public bool finalInstructionsHasOpened = false;


    // Start is called before the first frame update
    void Start()
    {
        //Set all arrows to initially closed
        arrowInfo.SetActive(false);
        arrowEquation.SetActive(false);
        arrowBuild.SetActive(false);
        arrowTable.SetActive(false);
        arrowGraph.SetActive(false);
        arrowFinal.SetActive(false);

        //Set all instruction stages for each page to be open
        tableInstructions.SetActive(true);
        graphInstructions.SetActive(true);
        graphInstructions.SetActive(true);
    }
}
