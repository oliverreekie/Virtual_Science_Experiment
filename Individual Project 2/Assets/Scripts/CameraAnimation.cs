using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    //Max and min values for camera movement
    private float zMax = 23;
    private float zMin = 3;
    //Is the camera moving left or right
    private bool isRight = true;

    void Update()
    {
        //If camera reaches edges, reverse direction
        if(this.transform.position.z >= 23)
        {
            isRight = false;
        }
        else if (this.transform.position.z <= 3)
        {
            isRight = true;
        }
        //Move camera to the right
        if (isRight == true)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1.5f * Time.deltaTime);
        }
        //Move camera to the left
        else
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1.5f * Time.deltaTime);
        }
    }
}
