using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GraphTitleScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isHolding = false;

    private Vector2 pointLocation;

    public GameObject createInputField;

    public GameObject graphCanvas;

    private bool isRotated = false;

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
        pointLocation = new Vector2(389, -630);
    }

    void Update()
    {
        if (isHolding == true)
        {
            if (pointLocation == new Vector2(389, -630))
            {
                InstantiateNewInputField();
            }

            pointLocation = new Vector2(this.transform.position.x, this.transform.position.y);
            //print(pointLocation);
            this.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z);
        }

/*        //Should it rotate
        if (this.transform.position.x <= 1100)
        {
            if(isRotated == false)
            {
                this.transform.rotation = new Quaternion(180, -180, 0, 0);
                isRotated = true;
                print("yep");
            }
        }*/
    }

    private Vector2 getPointLocation()
    {
        return pointLocation;
    }

    private void InstantiateNewInputField()
    {
        Instantiate(createInputField, new Vector3(1669, 90, this.transform.position.z), new Quaternion(0, 0, 0, 0), graphCanvas.transform);
    }
}
