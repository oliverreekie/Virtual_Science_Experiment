using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldPointScript : MonoBehaviour
{
    //Sets up class as singleton
    public static HoldPointScript Instance { get; private set; }

    //If the player is holding an object
    private bool isHolding = false;

    //What object is being held
    private string objHolding = "";

    //What object is being looked at
    private string lookingAt = "";

    //Ensures only one instance exists - for singleton
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

    //Getters and setters
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
