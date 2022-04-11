using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewVolumeCtrl : MonoBehaviour
{
  

   public void ChangeVol(float newValue)
    {
        float newVol = AudioListener.volume;
        newVol = newValue;
        AudioListener.volume = newVol;
    }
}
