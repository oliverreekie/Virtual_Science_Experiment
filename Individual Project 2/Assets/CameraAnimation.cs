using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{

    private float zMax = 23;
    private float zMin = 3;
    private bool isRight = true;

    void Update()
    {
        if(this.transform.position.z >= 23)
        {
            isRight = false;
        }
        else if (this.transform.position.z <= 3)
        {
            isRight = true;
        }

        if (isRight == true)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1.5f * Time.deltaTime);
        }
        else
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1.5f * Time.deltaTime);
        }
    }
}
