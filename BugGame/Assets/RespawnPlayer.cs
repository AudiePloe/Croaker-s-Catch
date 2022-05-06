using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{

    Vector3 startPos;



    void Start()
    {
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.localPosition.y <= -20f)
        {
            ResetPlayerPos();
        }

    }



    public void ResetPlayerPos()
    {
        transform.position = startPos;
    }


}
