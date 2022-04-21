using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 0.1f;

    void Update()
    {
        if (BuildState.Instance.getRulerCanvasOpen() == false && BuildState.Instance.getNotesCanvasOpen() == false && BuildState.Instance.getGraphCanvasOpen() == false)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);
        }
    }

}
