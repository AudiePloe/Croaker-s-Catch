using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{

    public GameObject BlackPic;
    public GameObject ColorPic;


    public void SwapPic()
    {
        BlackPic.SetActive(false);
        ColorPic.SetActive(true);
    }

    public void resetImages()
    {
        BlackPic.SetActive(true);
        ColorPic.SetActive(false);
    }

}
