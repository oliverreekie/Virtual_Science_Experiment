using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GraphLabelScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isHolding = false;

    private Vector2 pointLocation;

    public GameObject createInputField;

    public GameObject graphCanvas;

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;


        if (this.transform.position.x >= 2347 && this.transform.position.x <= 2479)
        {
            if (this.transform.position.y >= 99 && this.transform.position.y <= 247)
            {
                Destroy(createInputField);
            }
        }        
    }

    void Start()
    {
        pointLocation = new Vector2(440, -544);
    }

    void Update()
    {
        if (isHolding == true)
        {
            if (pointLocation == new Vector2(440, -544))
            {
                InstantiateNewInputField();
            }

            pointLocation = new Vector2(this.transform.position.x, this.transform.position.y);
            //print(pointLocation);
            this.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z);
        }
    }

    private Vector2 getPointLocation()
    {
        return pointLocation;
    }

    private void InstantiateNewInputField()
    {
        Instantiate(createInputField, new Vector3(1720, 176, this.transform.position.z), new Quaternion(0, 0, 0, 0), graphCanvas.transform);
    }
}
