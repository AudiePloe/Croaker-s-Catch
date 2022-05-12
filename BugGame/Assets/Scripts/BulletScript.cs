// Audie Ploe

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
            pc.addBug(col.gameObject);
        }

        Destroy(gameObject); // destroy the bullet
    }

}
