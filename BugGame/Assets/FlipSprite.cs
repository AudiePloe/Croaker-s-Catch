using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{

    public GameObject BlackPic;
    public GameObject ColorPic;

    public GameObject NoInfo;
    public GameObject FilledInfo;


    public void SwapPic()
    {
        BlackPic.SetActive(false);
        ColorPic.SetActive(true);

        NoInfo.SetActive(false);
        FilledInfo.SetActive(true);

    }

    public void resetImages()
    {
        BlackPic.SetActive(true);
        ColorPic.SetActive(false);

        NoInfo.SetActive(true);
        FilledInfo.SetActive(false);

    }

}
