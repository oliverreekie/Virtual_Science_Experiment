using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingArrow : MonoBehaviour
{
    private bool up;

    // Start is called before the first frame update
    void Start()
    {
        up = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(up == false)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - (float)(1 * Time.deltaTime), this.transform.position.z);
        }
        else
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (float)(1 * Time.deltaTime), this.transform.position.z);
        }

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
