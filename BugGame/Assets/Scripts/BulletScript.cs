using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    PlayerCatch pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCatch>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Bug")
        {
            GameDataStatic.bugsCaught++;

            if (col.gameObject.name == "Moth(Clone)")
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

            col.gameObject.GetComponent<BugScript>().DestroyBug(); // destroy the bug gameobject
        }

        Destroy(gameObject); // destroy the bullet
    }

}
