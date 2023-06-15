using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToggleController : MonoBehaviour, IPointerDownHandler
{

    //Whether background piano music is player
    public bool musicIsOn;

    //Whether special effects are toggled on
    public bool specialIsOn;

    public AudioController audioController;


    // Start is called before the first frame update
    void Start()
    {
        //Initially set background music and special effects to on
        musicIsOn = true;
        specialIsOn = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Start and stop piano
        if(this.name == "Music")
        {
            if(musicIsOn == true)
            {
                musicIsOn = false;
                audioController.StopPiano();
            }
            else
            {
                musicIsOn = true;
                audioController.StartPiano();
            }
        }
        //Start and stop special effects
        else if(this.name == "Special")
        {
            if(specialIsOn == true)
            {
                specialIsOn = false;
                audioController.specialIsPlaying = false;
            }
            else
            {
                specialIsOn = true;
                audioController.specialIsPlaying = true;
            }
        }
    }

}
