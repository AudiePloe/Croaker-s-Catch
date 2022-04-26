using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFade : MonoBehaviour
{

    public CanvasGroup fade;

    public float fadeRate;

    void Start()
    {
        resetFade();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(fade.alpha != 1)
        {
            fade.alpha += fadeRate * Time.deltaTime;
        }


        if(!gameObject.activeInHierarchy)
        {
            fade.alpha = 0;
        }

    }


    public void resetFade()
    {
        fade.alpha = 0;
    }

}
