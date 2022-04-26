using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerCatch : MonoBehaviour
{
    public JournalController journalcontrol;
    public PlayerController PC;
    public Animator FrogController;
    public Text bugsCaughtText;
    public int bugsCaught = 0;
    bool swing = false;

    public float swingRate;
    float time = 10f;


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



    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Bug")
        {
            col.GetComponent<BugScript>().lightSource.SetActive(false);
        }
    }


    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Bug")
        {
            col.GetComponent<BugScript>().lightSource.SetActive(true);
        }



        if(col.gameObject.tag == "Bug" && swing)
        {
            addBug(col.gameObject);
        }
    }

    public void addBug(GameObject bug)
    {
        print("PlayerCaughtBug");
        GameDataStatic.bugsCaught++;

        if (bug.name == "Moth(Clone)")
        {
            GameDataStatic.moths++;
        }
        else if (bug.name == "JewelBeetle(Clone)")
        {
            GameDataStatic.jewelBeetle++;
        }
        else if (bug.name == "FireflyBeetle(Clone)")
        {
            GameDataStatic.firefly++;
        }
        else if (bug.name == "Rhinobeetle(Clone)")
        {
            GameDataStatic.rhinobeetle++;
        }
        else if (bug.name == "Ladybug(Clone)")
        {
            GameDataStatic.ladybug++;
        }
        else if (bug.name == "Bee(Clone)")
        {
            GameDataStatic.bee++;
        }
        else if (bug.name == "Butterfly(Clone)")
        {
            GameDataStatic.butterfly++;
        }
        else if (bug.name == "Psudoscorpian(Clone)")
        {
            GameDataStatic.scorpian++;
        }
        else if (bug.name == "Snail(Clone)")
        {
            GameDataStatic.snail++;
        }
        else if (bug.name == "Spider(Clone)")
        {
            GameDataStatic.spider++;
        }

        bug.GetComponent<BugScript>().DestroyBug();


        journalcontrol.checkAlerts();
    }




}
