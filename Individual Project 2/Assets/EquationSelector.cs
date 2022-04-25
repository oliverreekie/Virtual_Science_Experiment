using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EquationSelector : MonoBehaviour
{

    public EquationController equationController;

    public GameObject equationToSet;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        equationToSet.SetActive(true);
        if(this.name == "Green SUVAT 3")
        {
            equationController.setIfCorrect(true);
        }
    }
}
