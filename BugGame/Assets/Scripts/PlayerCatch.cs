using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerCatch : MonoBehaviour
{
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


        if(Input.GetKey(KeyCode.Mouse0) && time >= swingRate)
        {
            // play animation for swinging net

            print("PlayerSwing");
            swing = true;
            swingNet();
            
        }

        bugsCaughtText.text = "Bugs Caught: " + bugsCaught;
    }

    IEnumerator swingNet()
    {
        time = 0;
        yield return new WaitForSeconds(0.5f);
    }



    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Bug" && swing)
        {
            print("PlayerCaughtBug");
            bugsCaught++;
            BugScript bs = col.GetComponent<BugScript>();
            bs.DestroyBug();
        }
    }

}
