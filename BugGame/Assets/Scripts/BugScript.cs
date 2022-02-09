using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BugScript : MonoBehaviour
{

    public float walkSpeed; // how fast it normally moves

    public float wonderDistance; // how far it will wonder on its own

    public float idleTimer; // time in between walking around

    public float runSpeed; // how fast it runs

    public List<Transform> hidingSpots; // list of positions it can run to

    bool idle = true; // if its not running
    float time; // used for timing
    NavMeshAgent nav; // the NavMeshAgent attached to the bug


    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        time = Random.Range(0.0f, 1.2f); // so that each bug is on their own idle times, otherwise they would all move at once.

        nav.speed = walkSpeed;
    }

    
    void Update()
    {
        time += Time.deltaTime;

        if (idle) // if allowed to idle
        {
            while (time >= idleTimer) // while the time is less than their idle time
            {
                nav.destination = IdleWalk(); // set destination of nav mesh agent to random position
            }
        }
    }


    Vector3 IdleWalk() // chooses a random position to walk to
    {
        print("AI Walking");

        time = 0;

        Vector3 randomDirection = Random.insideUnitSphere * wonderDistance; // sets a random point in a circle with the radius of walkradius

        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, wonderDistance, 1); // selects position on a navmesh

        return hit.position;


    }


    private void OnTriggerStay(Collider col) // when object with tag "Player" is in a trigger collider stop idling and move towars it
    {
        if (col.gameObject.tag == "Player")
        {
            print("AI Running");

            idle = false;

            nav.speed = runSpeed; // make the bug run from player
            nav.destination = GetHidingSpot().position;
        }


        if(col.gameObject.tag == "HidingSpot")
        {
            Destroy(gameObject); // might need to be changed later to have them transform somewhere else instead of destroy to save processing power
        }



    }


    private Transform GetHidingSpot() // selects a random hiding spot for them to run to.
    {
        int randpos = Random.Range(0, hidingSpots.Count);
        return hidingSpots[randpos];
    }

}
