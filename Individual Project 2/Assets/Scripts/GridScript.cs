using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GridScript : Graphic
{
    public int rows;
    public int columns;

    float width;
    float height;

    float widthOfLine = (float)4;

    float totalWidth;
    float totalHeight;

    public TextMeshProUGUI rowText;
    public TextMeshProUGUI columnText;

    public GameObject tableCanvas;

    public TMP_InputField theField;

    private int rowValue;

    private int columnValue;

    private List<TMP_InputField> currentInputFields = new List<TMP_InputField>();

    public GameObject theLocation;

    public GradingTracker gradingTracker;

    public void Start()
    {
        rowValue = 1;
        columnValue = 1;

    }

    private void Update()
    {
        rows = Int32.Parse(rowText.text);
        columns = Int32.Parse(columnText.text);

        //Checks if the values have been changed
        if(rows != rowValue || columns != columnValue)
        {
            //Remove current fields
            for(int i = 0; i < currentInputFields.Count; i++)
            {
                Destroy(currentInputFields[i].gameObject);
                gradingTracker.graphHeaders.Clear();
                gradingTracker.allTableFields.Clear();
            }

            //Empties list
            currentInputFields.Clear();

            //Add new fields
            float ySize = (520 * 2) / rows;
            float xSize = 400 / columns;


            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    float rowHold = 0;
                    if(rows == 1)
                    {
                        rowHold = 423;
                    }
                    if(rows == 2)
                    {
                        rowHold = 188;
                    }
                    else if(rows == 3)
                    {
                        rowHold = 108;
                    }
                    else if (rows == 4)
                    {
                        rowHold = 71;
                    }
                    else if (rows == 5)
                    {
                        rowHold = 47;
                    }
                    else if (rows == 6)
                    {
                        rowHold = 26;
                    }
                    else if (rows == 7)
                    {
                        rowHold = 18;
                    }
                    else if (rows == 8)
                    { 
                        rowHold = 9;
                    }
                    else if (rows == 10)
                    {
                        rowHold = -4;
                    }
                    else if (rows == 11)
                    {
                        rowHold = -6;
                    }
                    else if (rows == 12)
                    {
                        rowHold = -9;
                    }
                    else if (rows == 13)
                    {
                        rowHold = -13;
                    }
                    else if (rows == 14)
                    {
                        rowHold = -16;
                    }
                    else if (rows == 15)
                    {
                        rowHold = -18;
                    }
                    else if (rows == 16)
                    {
                        rowHold = -20;
                    }
                    else if (rows == 17)
                    {
                        rowHold = -21;
                    }
                    else if (rows == 18)
                    {
                        rowHold = -23;
                    }
                    else if (rows == 19)
                    {
                        rowHold = -24;
                    }

                    float columnHold = 0;
                    if(columns == 1)
                    {
                        columnHold = -283;
                    }
                    else if(columns == 2)
                    {
                        columnHold = -99;
                    }
                    else if (columns == 3)
                    {
                        columnHold = -41;
                    }
                    else if (columns == 4)
                    {
                        columnHold = -10;
                    }
                    else if (columns == 5)
                    {
                        columnHold = 10;
                    }
                    else if (columns == 6)
                    {
                        columnHold = 22;
                    }
                    else if (columns == 7)
                    {
                        columnHold = 28;
                    }
                    else if (columns == 8)
                    {
                        columnHold = 34;
                    }


                    if (i == 0 && j == 0)
                    {
                        InstantiateInputField(new Vector3(theLocation.transform.position.x - columnHold, theLocation.transform.position.y - rowHold, 0), 0);
                    }
                    else
                    {
                        float columnAmount = 738 / columns;
                        float rowAmount = 954 / rows;

                        //If in row one, for grading system
                        if (i == 0)
                        {
                            InstantiateInputField(new Vector3(theLocation.transform.position.x + (columnAmount * j) - columnHold, theLocation.transform.position.y - (rowAmount * i) - rowHold, 0), 0);
                        }
                        else
                        {
                            InstantiateInputField(new Vector3(theLocation.transform.position.x + (columnAmount * j) - columnHold, theLocation.transform.position.y - (rowAmount * i) - rowHold, 0), 1);
                        }

                    }
                }
            }

            //Reszing the input fields
            for(int i = 0; i < currentInputFields.Count; i++)
            {
                currentInputFields[i].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (954 / rows) - 2);
                currentInputFields[i].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (738 / columns) - 8);
            }

        }

        rowValue = rows;
        columnValue = columns;

        SetVerticesDirty();
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {

        vh.Clear();

        totalWidth = rectTransform.rect.width;
        totalHeight = rectTransform.rect.height;

        width = totalWidth / (float)columns;
        height = totalHeight / (float)rows;

        int counter = 0;

        for(int i = 0; i < columns; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                createSquare(i, j, counter, vh);
                counter++;
            }
        }

    }

    void createSquare(int x, int y, int counter, VertexHelper vh)
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

    private void InstantiateInputField(Vector3 v, int i)
    {
        //Instantiate(theField, v, new Quaternion(0, 0, 0, 0), tableCanvas.transform);
        //currentInputFields.Add(Instantiate(theField, v, new Quaternion(0, 0, 0, 0), tableCanvas.transform));
        if(i == 0)
        {
            TMP_InputField theSet = Instantiate(theField, v, new Quaternion(0, 0, 0, 0), tableCanvas.transform);
            currentInputFields.Add(theSet);
            gradingTracker.graphHeaders.Add(theSet);

            gradingTracker.allTableFields.Add(theSet);
        }
        else
        {
            TMP_InputField theSet = Instantiate(theField, v, new Quaternion(0, 0, 0, 0), tableCanvas.transform);
            currentInputFields.Add(theSet);

            gradingTracker.allTableFields.Add(theSet);
        }

    }
}
