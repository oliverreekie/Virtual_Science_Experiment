using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

//This class contains code reused from (Game Dev Guide, 2020)
//This reused code is found on the lines
//79-127, 130-211

public class GraphPaper : Graphic
{
    //Density of the paper
    private int numbers = 5;

    //Number of rows and columns of big squares
    int rows;
    int columns;

    //Size of graph paper
    float bigWidth;
    float bigHeight;

    //Number of rows and columns of small squares
    int smallRows;
    int smallColumns;

    //Size of big squares
    float smallWidth;
    float smallHeight;

    //Width of each set of lines
    float bigLineWidth = 3;
    float smallLineWidth = 1f;

    //Total width of page
    float totalWidth;
    float totalHeight;

    public GameObject graphCanvas;

    private int rowValue;

    private int columnValue;

    public void Start()
    {
        //Intitially set rows and columns to 1
        rowValue = 1;
        columnValue = 1;

    }

    private void Update()
    {
        //Sets global variables for rows and columns
        rowValue = rows;
        columnValue = columns;

        //Update lines in graphic class
        SetVerticesDirty();

        //Increase or decrease rows and columns with mouse scroll wheel
        numbers -= (int)Input.mouseScrollDelta.y;

        //Set maximum and minimum for number of rows
        if(numbers <= 1)
        {
            numbers = 1;
        }
        else if(numbers >= 15)
        {
            numbers = 15;
        }
    }

    //This method is reused from (Game Dev Guide, 2020) Modifications were made by myself to fit the project
    //Draw the graph paper
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        //Clear previous triangles
        vh.Clear();

        //Set the size of the graph paper
        totalWidth = rectTransform.rect.width;
        totalHeight = rectTransform.rect.height;

        //Set columns and rows (with rows proportionally equal based on page size) for large squares
        columns = numbers;
        rows = (int)Math.Round(numbers * 0.624);

        //Set columns and rows (with rows proportionally equal based on page size) for small squares
        smallColumns = numbers * 5;
        smallRows = (int)Math.Round(numbers * 0.624) * 5;

        //Calculate size of squares
        bigWidth = totalWidth / (float)columns;
        bigHeight = totalHeight / (float)rows;

        smallWidth = totalWidth / (float)smallColumns;
        smallHeight = totalHeight / (float)smallRows;

        int bigCounter = 0;

        //Create large squares to fill grid
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                createSquare(i, j, bigCounter, vh, bigLineWidth, bigWidth, bigHeight);
                bigCounter++;
            }
        }

        int smallCounter = 0;

        //Create small squares to fill grid
        for(int i = 0; i <= smallColumns + 2; i++)
        {
            for(int j = 0; j < smallRows; j++)
            {
                createSquare(i, j, smallCounter, vh, smallLineWidth, smallWidth, smallHeight);
                smallCounter++;
            }
        }

    }

    //This method is reused from (Game Dev Guide, 2020)
    //Create a square
    void createSquare(int x, int y, int counter, VertexHelper vh, float widthOfLine, float width, float height)
    {
        //Set size of the square
        float xPos = (width * x) - (int)(totalWidth / 2);
        float yPos = (height * y) - (int)(totalHeight / 2);

        //Start drawing
        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        //For each side calculate the coordinates and draw triangles between each of them

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
