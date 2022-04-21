using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldPointScript : MonoBehaviour
{
    public static HoldPointScript Instance { get; private set; }

    private bool isHolding = false;

    private string objHolding = "";

    private string lookingAt = "";
    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setIsHolding(bool b)
    {
        isHolding = b;
    }

    public bool getIsHolding()
    {
        return isHolding;
    }

    public void setObjHolding(string s)
    {
        objHolding = s;
    }

    public string getObHolding()
    {
        return objHolding;
    }
    public void setLookingAt(string s)
    {
        lookingAt = s;
    }

    public string getLookingAt()
    {
        return lookingAt;
    }
}
