using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquationSelector : MonoBehaviour
{
    //Equation controller
    public EquationController equationController;

    //Equation component
    public GameObject equationToSet;

    // Start is called before the first frame update
    void Start()
    {
        //Set up button listener
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        //Set as correct when clicked
        equationToSet.SetActive(true);
        if(this.name == "Green SUVAT 3")
        {
            equationController.setIfCorrect(true);
        }
    }
}
