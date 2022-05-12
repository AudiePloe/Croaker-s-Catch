// Audie Ploe

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;

    float sliderValue;


    void Start()
    {
        slider.value = GameDataStatic.gameVolume;
        sliderValue = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        GameDataStatic.gameVolume = slider.value;

        AudioListener.volume = GameDataStatic.gameVolume;

    }
}
