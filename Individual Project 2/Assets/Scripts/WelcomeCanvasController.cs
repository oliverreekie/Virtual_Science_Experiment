using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class WelcomeCanvasController : MonoBehaviour
{
    //The current stage the user is on
    public int stageNumber = 1;

    //Each stage of tutorial
    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
    public GameObject stage4;
    public GameObject stage5;

    public TextMeshProUGUI theText;

    public CanvasController canvasController;


    // Start is called before the first frame update
    void Start()
    {
        stage1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Show current stage number to user
        theText.text = stageNumber + " of 5";

        //Show relevent information on stage
        if(stageNumber == 1)
        {
            stage1.SetActive(true);
            stage2.SetActive(false);
            stage3.SetActive(false);
            stage4.SetActive(false);
            stage5.SetActive(false);
        }
        if (stageNumber == 2)
        {
            stage1.SetActive(false);
            stage2.SetActive(true);
            stage3.SetActive(false);
            stage4.SetActive(false);
            stage5.SetActive(false);
        }
        if (stageNumber == 3)
        {
            stage1.SetActive(false);
            stage2.SetActive(false);
            stage3.SetActive(true);
            stage4.SetActive(false);
            stage5.SetActive(false);
        }
        if (stageNumber == 4)
        {
            stage1.SetActive(false);
            stage2.SetActive(false);
            stage3.SetActive(false);
            stage4.SetActive(true);
            stage5.SetActive(false);
        }
        if (stageNumber == 5)
        {
            stage1.SetActive(false);
            stage2.SetActive(false);
            stage3.SetActive(false);
            stage4.SetActive(false);
            stage5.SetActive(true);
        }
    }

}
