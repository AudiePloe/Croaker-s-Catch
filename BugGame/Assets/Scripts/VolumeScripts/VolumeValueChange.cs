using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValueChange : MonoBehaviour
{
    private AudioSource AudioSrc;

    private float AudioVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        AudioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSrc.volume = AudioVolume;
    
}
    public void SetVolume(float vol)
    {
        AudioVolume = vol;
    }
}
