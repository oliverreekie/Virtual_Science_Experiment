using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropButtonScript : MonoBehaviour
{
    public ArrowScript arrowScript;

    public GameObject weightedCard;

    public CanvasController rulerController;

    public PickUp weightedCardPickUp;

    void Start()
    {
        //Set up button
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        //Set position to transform card to
        double toDropY = (0.01989 * arrowScript.getArrowLocation()) + 2.7602;
        //Set position and rotation
        weightedCard.transform.position = new Vector3((float)-5.196, (float)toDropY, (float)5.538);
        weightedCard.transform.rotation = new Quaternion(-90, -90, 0, 0);
        //Close ruler and drop card
        rulerController.swapRulerState();
        weightedCardPickUp.droppingCardFromRuler();
    }
}
