using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject grey;

    public GameObject colour;

    private bool determinationGActive = false;

    void Update()
    {
        if (determinationGActive == false)
        {
            if (Input.mousePosition.x >= 273.1 && Input.mousePosition.x <= 608.7)
            {
                if (Input.mousePosition.y >= 998.6 && Input.mousePosition.y <= 1173)
                {
                    grey.SetActive(false);
                    colour.SetActive(true);
                }
                else
                {
                    grey.SetActive(true);
                    colour.SetActive(false);
                }
            }
            else
            {
                grey.SetActive(true);
                colour.SetActive(false);
            }
        }
        if(determinationGActive == true)
        {
            grey.SetActive(false);
            colour.SetActive(true);
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //If over the determination of g button
        if (determinationGActive == false)
        {
            if (Input.mousePosition.x >= 273.1 && Input.mousePosition.x <= 608.7)
            {
                if (Input.mousePosition.y >= 998.6 && Input.mousePosition.y <= 1173)
                {
                    determinationGActive = true;
                }
            }
        }

        //If over the start practical button
        if(determinationGActive == true)
        {
            if(Input.mousePosition.x <= 1174 && Input.mousePosition.x >= 875)
            {
                if(Input.mousePosition.y <= 350 && Input.mousePosition.y >= 258)
                {
                    SceneManager.LoadScene(sceneName: "Determination_of_g_scene");
                }
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }
}
