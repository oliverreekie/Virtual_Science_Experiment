using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //Audio players for each sound
    public AudioSource paperFlip;
    public AudioSource click;
    public AudioSource whoosh;
    public AudioSource piano;

    //Whether the special effects is toggled on or off
    public bool specialIsPlaying;

    // Start is called before the first frame update
    void Start()
    {
        //Start the piano on game load
        StartPiano();
        //Initially toggle special effects to on
        specialIsPlaying = true;
    }

    //Play paper rustle when user opens or closes a page
    public void PickUpPaper()
    {
        if(specialIsPlaying == true)
        {
            paperFlip.Play();
        }
    }
    //Play a click when the user connects an apparatus piece
    public void AttachClick()
    {
        if (specialIsPlaying == true)
        {
            click.Play();
        }
    }
    //Play a whoosh when the player drops the card
    public void StartWhoosh()
    {
        if (specialIsPlaying == true)
        {
            whoosh.Play();
        }
    }
    //Play and pause the piano background music
    public void StartPiano()
    {
        piano.Play();
    }
    public void StopPiano()
    {
        piano.Pause();
    }
}
