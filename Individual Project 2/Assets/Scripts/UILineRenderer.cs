using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//This class contains code reused from (Game Dev Guide, 2020)
//This reused code is found on the lines
//81-142
public class UILineRenderer : Graphic, IPointerDownHandler, IPointerUpHandler
{
    //Size of graph paper
    public Vector2Int gridSize;

    //List of start and end points of line
    public List<Vector2> points;

    //Width and height of line
    float width;
    float height;
    float unitWidth;
    float unitHeight;

    //Thickness of line
    public float thickness = 10f;

    //Whether the user is holding the mouse
    public bool isHolding = false;

    public CanvasController canvasController;

    public Image posImage;

    public GradingTracker gradientTracker;

    void Start()
    {
        points[0] = new Vector2(0, 0);
        points[1] = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(canvasController.isDrawing == true)
        {
            //If user is holding the mouse, set second point to mouse location
            if (isHolding == true)
            {
                points[1] = new Vector2(Mathf.Round(Input.mousePosition.x - (1185 + 655)), Mathf.Round(Input.mousePosition.y - (496 + 405)));
            }

            //Reset graphics class
            SetVerticesDirty();
        }
    }

    //When the user presses the mouse
    public void OnPointerDown(PointerEventData eventData)
    {
        //Start drawing and set first point to where the mouse was clicked
        if (canvasController.isDrawing == true)
        {
            points[0] = new Vector2(Mathf.Round(Input.mousePosition.x - 1840), Mathf.Round(Input.mousePosition.y - 901));
            isHolding = true;
        }
    }

    //Set second location to where the mouse was released
    public void OnPointerUp(PointerEventData eventData)
    {
        if(canvasController.isDrawing == true)
        {
            points[1] = new Vector2(Mathf.Round(Input.mousePosition.x - (1185 + 655)), Mathf.Round(Input.mousePosition.y - (496 + 405)));
            isHolding = false;
        }
        printGradient();
    }

    //This method is reused from (Game Dev Guide, 2020)
    //Rotate line to have consistent width throughout
    public float GetAngle(Vector2 me, Vector2 target)
    {
        return (float)(Mathf.Atan2(target.y - me.y, target.x - me.x) * (180 / Mathf.PI));
    }

    //This method is reused from (Game Dev Guide, 2020)
    //Draw triangles
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        //Clear current verticies
        vh.Clear();

        //Set graph size
        width = rectTransform.rect.width;
        height = rectTransform.rect.height;

        unitWidth = width / (float)gridSize.x;
        unitHeight = height / (float)gridSize.y;

        //Cancel if line is not drawn
        if(points.Count < 2)
        {
            return;
        }

        float angle = 0;

        //Draw line between points
        for(int i = 0; i < points.Count; i++)
        {
            Vector2 point = points[i];

            if(i < points.Count - 1)
            {
                angle = GetAngle(points[i], points[i + 1]) + 45f;
            }
            DrawVerticiesForPoint(point, vh, angle);
        }

        //Add points to vertex helper
        for(int i = 0; i < points.Count - 1; i++)
        {
            int index = i * 2;
            vh.AddTriangle(index + 0, index + 1, index + 3);
            vh.AddTriangle(index + 3, index + 2, index + 0);
        }
    }

    //This method is reused from (Game Dev Guide, 2020)
    //Draw two triangles between points to create a line
    void DrawVerticiesForPoint(Vector2 point, VertexHelper vh, float angle)
    {
        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        vertex.position = Quaternion.Euler(0, 0, angle) *  new Vector3(-thickness / 2, 0);
        vertex.position += new Vector3(unitWidth * point.x, unitHeight * point.y);
        vh.AddVert(vertex);

        vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(thickness / 2, 0);
        vertex.position += new Vector3(unitWidth * point.x, unitHeight * point.y);
        vh.AddVert(vertex);

    }

    //Save line points to grading tracker
    void printGradient()
    {
        double calcActualGradient = (points[1].y - points[0].y) / (points[1].x - points[0].x);

        gradientTracker.calculatedGradient = calcActualGradient;
    }
}
