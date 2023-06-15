using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GraphTitleScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //Whether the user is holding the label
    private bool isHolding = false;

    //Location of label
    private Vector2 pointLocation;

    //New inputfield to instantiate
    public GameObject createInputField;

    public GameObject graphCanvas;

    //Whether the label has been rotated
    private bool isRotated = false;

    //Locators in the scene
    public GameObject leftGuide;
    public GameObject binLocator;
    public GameObject spawnLocator;

    public GradingTracker gradingTracker;

    //Pick up label on mouse down
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
        if (distance <= 80)
        {
            Destroy(createInputField);
        }
    }

    void Start()
    {
        //Initially set location to spawn
        pointLocation = new Vector2(389, -630);

        //Add label to list in grading tracker
        gradingTracker.graphLabels.Add(this.gameObject);
    }

    void Update()
    {
        //If the user picks up in the spawn area, create a new inputfield in the spawn
        if (isHolding == true)
        {
            if (pointLocation == new Vector2(389, -630))
            {
                InstantiateNewInputField();
            }

            //Move inputfield with mouse
            pointLocation = new Vector2(this.transform.position.x, this.transform.position.y);
            this.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z);
        }

        //Should it rotate
        if (this.transform.position.x <= leftGuide.transform.position.x)
        {
            if (isRotated == false)
            {
                //Rotate anti-clockwise
                this.transform.rotation = Quaternion.Euler(0, 0, 90);
                isRotated = true;
            }
        }
        else if(this.transform.position.x > leftGuide.transform.position.x)
        {
            if (isRotated == true)
            {
                //Rotate clockwise
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

    //Spawn a new inputfield
    private void InstantiateNewInputField()
    {
        Instantiate(createInputField, new Vector3(spawnLocator.transform.position.x, spawnLocator.transform.position.y, this.transform.position.z), new Quaternion(0, 0, 0, 0), graphCanvas.transform);

    }
}
