using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GraphPaper : Graphic
{
    private int numbers = 5;

    int rows;
    int columns;

    float bigWidth;
    float bigHeight;


    int smallRows;
    int smallColumns;

    float smallWidth;
    float smallHeight;

    float bigLineWidth = 3;
    float smallLineWidth = 1f;

    float totalWidth;
    float totalHeight;

    public GameObject graphCanvas;

    private int rowValue;

    private int columnValue;

    public void Start()
    {
        rowValue = 1;
        columnValue = 1;

    }

    private void Update()
    {

        rowValue = rows;
        columnValue = columns;

        SetVerticesDirty();

        numbers += (int)Input.mouseScrollDelta.y;

        if(numbers <= 1)
        {
            numbers = 1;
        }
        else if(numbers >= 15)
        {
            numbers = 15;
        }

        //print(numbers);
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {

        vh.Clear();

        totalWidth = rectTransform.rect.width;
        totalHeight = rectTransform.rect.height;

        columns = numbers;
        rows = (int)Math.Round(numbers * 0.624);

        smallColumns = numbers * 5;
        smallRows = (int)Math.Round(numbers * 0.624) * 5;

        bigWidth = totalWidth / (float)columns;
        bigHeight = totalHeight / (float)rows;

        smallWidth = totalWidth / (float)smallColumns;
        smallHeight = totalHeight / (float)smallRows;

        int bigCounter = 0;

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                createSquare(i, j, bigCounter, vh, bigLineWidth, bigWidth, bigHeight);
                bigCounter++;
            }
        }

        int smallCounter = 0;

        for(int i = 0; i < smallColumns; i++)
        {
            for(int j = 0; j < smallRows; j++)
            {
                createSquare(i, j, smallCounter, vh, smallLineWidth, smallWidth, smallHeight);
                smallCounter++;
            }
        }

    }

    void createSquare(int x, int y, int counter, VertexHelper vh, float widthOfLine, float width, float height)
    {
        float xPos = (width * x) - (int)(totalWidth / 2);
        float yPos = (height * y) - (int)(totalHeight / 2);

        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        //Left Side
        vertex.position = new Vector3(xPos, yPos);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos, yPos + height);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + widthOfLine, yPos + height);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + widthOfLine, yPos);
        vh.AddVert(vertex);

        //Top Side
        vertex.position = new Vector3(xPos, yPos + height);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + width, yPos + height);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + width, yPos + (height - widthOfLine));
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos, yPos + (height - widthOfLine));
        vh.AddVert(vertex);

        //Right Side
        vertex.position = new Vector3(xPos + width, yPos + height);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + width, yPos);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + (width - widthOfLine), yPos);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + (width - widthOfLine), yPos + height);
        vh.AddVert(vertex);

        //Bottom Side
        vertex.position = new Vector3(xPos + width, yPos);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos, yPos);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos, yPos + widthOfLine);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + width, yPos + widthOfLine);
        vh.AddVert(vertex);

        int offset = counter * 16;

        //Left Side
        vh.AddTriangle(offset + 0, offset + 1, offset + 2);
        vh.AddTriangle(offset + 2, offset + 3, offset + 0);

        //Top Side
        vh.AddTriangle(offset + 4, offset + 5, offset + 6);
        vh.AddTriangle(offset + 6, offset + 7, offset + 4);

        //Right Side
        vh.AddTriangle(offset + 8, offset + 9, offset + 10);
        vh.AddTriangle(offset + 10, offset + 11, offset + 8);

        //Bottom Side
        vh.AddTriangle(offset + 12, offset + 13, offset + 14);
        vh.AddTriangle(offset + 14, offset + 15, offset + 12);
    }

}
