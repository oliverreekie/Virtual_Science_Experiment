using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //The character controller
    public CharacterController controller;

    //Player speed
    public float speed = 0.1f;

    void Update()
    {
        //If any canvas is open, freeze the player
        if (BuildState.Instance.getRulerCanvasOpen() == false && BuildState.Instance.getNotesCanvasOpen() == false &&
            BuildState.Instance.getGraphCanvasOpen() == false && BuildState.Instance.getWelcomeCanvasOpen() == false &&
            BuildState.Instance.getMenuCanvasOpen() == false && BuildState.Instance.getInfoCanvasOpen() == false 
            && BuildState.Instance.getFinalCanvasOpen() == false)
        {
            //Move player based on input and considering framerate
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

        }

    }
}
