using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GraphPointScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isHolding = false;

    private Vector2 pointLocation;

    public GameObject createImage;

    public GameObject graphCanvas;

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
        if(distance <= 80)
        {
            Destroy(createImage);
        }

    }

    void Start()
    {
        pointLocation = new Vector2(9, -544);
    }

    void Update()
    {
        if(isHolding == true)
        {
            if(pointLocation == new Vector2(9, -544))
            {
                InstantiateNewImage();
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

    private void InstantiateNewImage()
    {
        Instantiate(createImage, new Vector3(spawnLocator.transform.position.x, spawnLocator.transform.position.y, this.transform.position.z), new Quaternion(0, 0, 0, 0), graphCanvas.transform);
    }
}
