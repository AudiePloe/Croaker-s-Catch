using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{

    Vector3 startPos; // position player spawned into the scene at

    public bool unStickPlayer = false;



    void Start()
    {
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z); // update position
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.localPosition.y <= -20f || unStickPlayer) // if player is out of bounds
        {
            ResetPlayerPos();
            unStickPlayer = false;
        }

    }



    public void ResetPlayerPos() 
    {
        transform.position = startPos;
    }


}
