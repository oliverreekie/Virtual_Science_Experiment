using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public Transform playerBody;

    public CanvasController rulerController;

    //Initial rotation of 0
    float xRotation = 0f;

    //Mouse sensitivity
    public float mouseSpeed = 100f; 

    void Update()
    {
        //If the canvases are open, show the mouse cursor
        if (rulerController.getRulerActive() == false && rulerController.getTableActive() == false && rulerController.getGraphActive() == false && 
            rulerController.getEquationActive() == false && rulerController.getWelcomeActive() == false && rulerController.getMenuActive() == false 
            && rulerController.getInfoActive() == false && rulerController.getFinalActive() == false && rulerController.getNotesActive() == false)
        {
            //If the canvases are closed, lock cursor to screen center and rotate camera with mouse movement
            float mouseX = Input.GetAxis("Mouse X") * 100f * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * 100f * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);

            Cursor.lockState = CursorLockMode.Locked;

        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
