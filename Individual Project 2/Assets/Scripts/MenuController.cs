using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject grey;

    public GameObject colour;

    private bool determinationGActive;

    public GameObject topRight;

    public GameObject bottomLeft;

    void Start()
    {
        colour.SetActive(false);
        determinationGActive = false;
    }

    void Update()
    {
        if (determinationGActive == false)
        {
            //If hovering over determination of g
            if (Input.mousePosition.x <= topRight.transform.position.x && Input.mousePosition.x >= bottomLeft.transform.position.x)
            {
                if (Input.mousePosition.y <= topRight.transform.position.y && Input.mousePosition.y >= bottomLeft.transform.position.y)
                {
                    colour.SetActive(true);
                }
            }
            else
            {
                colour.SetActive(false);
            }
        }

        print(determinationGActive);
    }

    public void SetDeterminationGActive(bool b)
    {
        determinationGActive = b;
    }

    public bool GetDeterminationGActive()
    {
        return determinationGActive;
    }


}
