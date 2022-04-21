using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetSliderValue : MonoBehaviour
{
    public TextMeshProUGUI theText;

    void Start()
    {
    }

    void Update()
    {
        theText.text = this.gameObject.GetComponent<Slider>().value.ToString();
    }
}
