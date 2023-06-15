using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GraphPointScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //Whether the user is holding the point
    private bool isHolding = false;

    //Location of point
    private Vector2 pointLocation;

    //New point to instantiate
    public GameObject createImage;

    public GameObject graphCanvas;

    //Locators in the scene
    public GameObject binLocator;
    public GameObject spawnLocator;
    public GradingTracker gradingTracker;

    //Pick up point on mouse down
    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
    }

    //Release on mouse up
    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;

        //Delete over bin button
        float distance = Vector3.Distance(this.transform.position, binLocator.transform.position);

        if(distance <= 80)
        {
            Destroy(createImage);
        }

    }

    void Start()
    {
        //Initially set location to spawn
        pointLocation = new Vector2(9, -544);

        gradingTracker.graphPoints.Add(this.gameObject);
    }

    void Update()
    {
        if(isHolding == true)
        {
            //If the user picks up in the spawn area, create a new point in the spawn
            if (pointLocation == new Vector2(9, -544))
            {
                InstantiateNewImage();
            }

            // Move point with mouse
             pointLocation = new Vector2(this.transform.position.x, this.transform.position.y);
            this.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z);
        }
    }

    private Vector2 getPointLocation()
    {
        return pointLocation;
    }

    //Spawn a new point
    private void InstantiateNewImage()
    {
        Instantiate(createImage, new Vector3(spawnLocator.transform.position.x, spawnLocator.transform.position.y, this.transform.position.z), new Quaternion(0, 0, 0, 0), graphCanvas.transform);
    }
}
