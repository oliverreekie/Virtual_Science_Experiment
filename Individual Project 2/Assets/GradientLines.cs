using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradientLines : MonoBehaviour
{

    public Vector2 firstCoordinate;
    public Vector2 secondCoordinate;

    public UILineRenderer uiLineRenderer;

    public GameObject xAxisMarker;

    public Image largeX;
    public Image smallX;

    public Image largeY;
    public Image smallY;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        firstCoordinate = uiLineRenderer.points[0];
        secondCoordinate = uiLineRenderer.points[1];

        largeX.rectTransform.sizeDelta = new Vector2(10, secondCoordinate.y + 406);
        largeX.transform.position = new Vector3(secondCoordinate.x + (1188 + 5 + 650), xAxisMarker.transform.position.y + (secondCoordinate.y + 406) / 2, this.transform.position.z);

        smallX.rectTransform.sizeDelta = new Vector2(10, firstCoordinate.y + 406);
        smallX.transform.position = new Vector3(firstCoordinate.x + (1188 + 5 + 650), xAxisMarker.transform.position.y + (firstCoordinate.y + 406) / 2, this.transform.position.z);

        largeY.rectTransform.sizeDelta = new Vector2((secondCoordinate.x + 640) / 2, 10);
        largeY.transform.position = new Vector3(xAxisMarker.transform.position.x + (secondCoordinate.x + 640) / 2,secondCoordinate.y + 905 , this.transform.position.z);

        smallY.rectTransform.sizeDelta = new Vector2((firstCoordinate.x + 640) / 2, 10);
        smallY.transform.position = new Vector3(xAxisMarker.transform.position.x + (firstCoordinate.x + 640) / 2, firstCoordinate.y + 905, this.transform.position.z);

        //print(secondCoordinate.x);

    }
}
