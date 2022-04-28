using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UILineRenderer : Graphic, IPointerDownHandler, IPointerUpHandler
{

    public Vector2Int gridSize;

    public List<Vector2> points;

    float width;
    float height;
    float unitWidth;
    float unitHeight;

    public float thickness = 10f;

    public bool isHolding = false;

    public CanvasController canvasController;

    public Image posImage;

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
            if (isHolding == true)
            {
                points[1] = new Vector2(Mathf.Round(Input.mousePosition.x - (1185 + 655)), Mathf.Round(Input.mousePosition.y - (496 + 405)));
            }

            SetVerticesDirty();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (canvasController.isDrawing == true)
        {
            points[0] = new Vector2(Mathf.Round(Input.mousePosition.x - 1840), Mathf.Round(Input.mousePosition.y - 901));
            isHolding = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(canvasController.isDrawing == true)
        {
            points[1] = new Vector2(Mathf.Round(Input.mousePosition.x - (1185 + 655)), Mathf.Round(Input.mousePosition.y - (496 + 405)));
            isHolding = false;
        }
    }

    public float GetAngle(Vector2 me, Vector2 target)
    {
        return (float)(Mathf.Atan2(target.y - me.y, target.x - me.x) * (180 / Mathf.PI));
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        width = rectTransform.rect.width;
        height = rectTransform.rect.height;

        unitWidth = width / (float)gridSize.x;
        unitHeight = height / (float)gridSize.y;

        if(points.Count < 2)
        {
            return;
        }

        float angle = 0;

        for(int i = 0; i < points.Count; i++)
        {
            Vector2 point = points[i];

            if(i < points.Count - 1)
            {
                angle = GetAngle(points[i], points[i + 1]) + 45f;
            }
            DrawVerticiesForPoint(point, vh, angle);
        }

        for(int i = 0; i < points.Count - 1; i++)
        {
            int index = i * 2;
            vh.AddTriangle(index + 0, index + 1, index + 3);
            vh.AddTriangle(index + 3, index + 2, index + 0);
        }
    }

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
}
