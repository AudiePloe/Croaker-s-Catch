using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>(); // finds the camera
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player); // makes object look at "player" position
    }
}
