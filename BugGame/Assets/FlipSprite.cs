using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour // used for changing the image and info of the bugs when caught
{

    public GameObject BlackPic;
    public GameObject ColorPic;

    public GameObject NoInfo;
    public GameObject FilledInfo;


    public void SwapPic() // swaps the blacked out images for the filled in ones.
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
