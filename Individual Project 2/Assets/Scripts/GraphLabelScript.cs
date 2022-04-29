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

    public GameObject binLocator;

    public GameObject spawnLocator;

    public GradingTracker gradingTracker;

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
        pointLocation = new Vector2(440, -544);

        gradingTracker.graphLineLabels.Add(this.gameObject);
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
        Instantiate(createInputField, new Vector3(spawnLocator.transform.position.x, spawnLocator.transform.position.y, this.transform.position.z), new Quaternion(0, 0, 0, 0), graphCanvas.transform);
    }
}
