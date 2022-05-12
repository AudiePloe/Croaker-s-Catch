using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{

    // this script was scrapped due to issues of changing the transform of the player in the scene







    [Header("Cave")]
    public Vector3 cavePos;
    public Quaternion caveRoatation;

    [Header("Flower")]
    public Vector3 FlowerPos;
    public Quaternion FlowerRotation;

    [Header("Player")]
    GameObject Player;



    bool movePlayer = true;
    public string SceneString = "";

    void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //Player = GameObject.Find("FrogPlayer");
        //Player = GameObject.FindGameObjectWithTag("Player");

        //if (movePlayer)
        //{
        //    if (SceneString == "Cave")
        //    {

        //        //Player.transform.position = new Vector3(cavePos.x, cavePos.y, cavePos.z);
        //        Player.transform.SetPositionAndRotation(cavePos, caveRoatation);
        //        //movePlayer = false;
        //        return;
        //    }

        //    if (SceneString == "FlowerLevel")
        //    {
        //        Player.transform.SetPositionAndRotation(FlowerPos, FlowerRotation);
        //        //movePlayer = false;
        //        return;
        //    }

        //}
    }






}
