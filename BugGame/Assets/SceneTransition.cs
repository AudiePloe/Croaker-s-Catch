using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup fade;
    public float fadeRate;


    void Start()
    {
        fade.alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(fade.alpha != 0)
        {
            fade.alpha -= Time.deltaTime * fadeRate;
        }
    }
}
