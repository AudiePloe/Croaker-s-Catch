using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerCatch : MonoBehaviour
{
    public PlayerController PC;
    public Animator FrogController;
    public Text bugsCaughtText;
    public int bugsCaught = 0;
    bool swing = false;

    public float swingRate;
    public float time = 10f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        swing = false;


        if(Input.GetKey(KeyCode.Mouse0) && time >= swingRate && PC.isGrounded)
        {
            // play animation for swinging net
            PC.canMove = false;
            FrogController.SetBool("isCatching", true);

            print("PlayerSwing");
            swing = true;
            Invoke("swingNet", swingRate);
            
        }
        

        bugsCaughtText.text = "Bugs Caught: " + GameDataStatic.bugsCaught;
    }

    void swingNet()
    {
        time = 0;
        PC.canMove = true;
        FrogController.SetBool("isCatching", false);
    }




    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Bug" && swing)
        {
            print("PlayerCaughtBug");
            GameDataStatic.bugsCaught++;

            if(col.gameObject.name == "Moth(Clone)")
            {
                GameDataStatic.moths++;
            } 
            else if (col.gameObject.name == "LargeBeetle(Clone)")
            {
                GameDataStatic.largeBeetle++;
            }
            else if (col.gameObject.name == "MediumBeetle(Clone)")
            {
                GameDataStatic.medBeetle++;
            }
            else if (col.gameObject.name == "FireflyBeetle(Clone)")
            {
                GameDataStatic.firefly++;
            }


            BugScript bs = col.GetComponent<BugScript>();
            bs.DestroyBug();

        }
    }

}
