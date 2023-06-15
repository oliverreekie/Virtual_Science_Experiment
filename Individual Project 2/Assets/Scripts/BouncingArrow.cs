using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingArrow : MonoBehaviour
{
    //Whether the arrow is moving up or down
    private bool up;

    // Start is called before the first frame update
    void Start()
    {
        up = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Slowly move arrow down
        if(up == false)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - (float)(1 * Time.deltaTime), this.transform.position.z);
        }
        //Slowly move arrow up
        else
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (float)(1 * Time.deltaTime), this.transform.position.z);
        }
        //If arrow reaches max or min point, reverse direction
        if(this.transform.position.y <= 2.3)
        {
            up = true;
        }
        else if(this.transform.position.y >= 3.0)
        {
            up = false;
        }
    }
}
