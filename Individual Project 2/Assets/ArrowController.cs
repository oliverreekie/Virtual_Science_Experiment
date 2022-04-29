using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameObject arrowInfo;
    public GameObject arrowEquation;
    public GameObject arrowBuild;
    public GameObject arrowTable;
    public GameObject arrowGraph;
    public GameObject arrowFinal;

    public GameObject tableInstructions;
    public GameObject graphInstructions;
    public GameObject finalInstructions;

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
        arrowInfo.SetActive(false);
        arrowEquation.SetActive(false);
        arrowBuild.SetActive(false);
        arrowTable.SetActive(false);
        arrowGraph.SetActive(false);
        arrowFinal.SetActive(false);

        tableInstructions.SetActive(true);
        graphInstructions.SetActive(true);
        graphInstructions.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
