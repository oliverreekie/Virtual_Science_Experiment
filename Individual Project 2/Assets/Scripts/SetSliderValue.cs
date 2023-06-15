using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetSliderValue : MonoBehaviour
{
    //Label to print slider number to
    public TextMeshProUGUI theText;

    void Update()
    {
        //Set label text to slider value
        theText.text = this.gameObject.GetComponent<Slider>().value.ToString();
    }
}
