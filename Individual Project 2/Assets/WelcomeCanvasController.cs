using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class WelcomeCanvasController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private int stageNumber = 1;

    public GameObject stage1;

    public TextMeshProUGUI theText;
    

    // Start is called before the first frame update
    void Start()
    {
        stage1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        theText.text = stageNumber + " of 6";
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //User selects back

        if (Input.mousePosition.x <= 2126 && Input.mousePosition.x > 2061)
        {
            if (Input.mousePosition.y <= 69.8 && Input.mousePosition.y >= 11.3)
            {
                print("hit");
            }
        }


        //User selects forward

        if (Input.mousePosition.x <= 2333 && Input.mousePosition.x > 2272)
        {
            if (Input.mousePosition.y <= 69.8 && Input.mousePosition.y >= 11.3)
            {
                print("hit");
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
