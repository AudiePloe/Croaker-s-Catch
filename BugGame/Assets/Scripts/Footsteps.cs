using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource theSound;
    
    public void playOneSound()
    {
        theSound.Play();
        Debug.Log("Play Sound");
    }
}
