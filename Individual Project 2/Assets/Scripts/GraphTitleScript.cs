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

    public GameObject leftGuide;

    public GameObject binLocator;

    public GameObject spawnLocator;

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;

        //Delete over bin button
        float distance = Vector3.Distance(this.transform.position, binLocator.transform.position);
        if (distance <= 80)
        {
            Destroy(createInputField);
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

        //Should it rotate
        if (this.transform.position.x <= leftGuide.transform.position.x)
        {
            if (isRotated == false)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 90);
                isRotated = true;
            }
        }
        else if(this.transform.position.x > leftGuide.transform.position.x)
        {
            if (isRotated == true)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                isRotated = false;
                print("yes");
            }
        }
    }

    private Vector2 getPointLocation()
    {
        return pointLocation;
    }

    private void InstantiateNewInputField()
    {
        Instantiate(createInputField, new Vector3(spawnLocator.transform.position.x, spawnLocator.transform.position.y, this.transform.position.z), new Quaternion(0, 0, 0, 0), graphCanvas.transform);
    }
}
