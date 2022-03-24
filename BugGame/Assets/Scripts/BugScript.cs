using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BugScript : MonoBehaviour
{
    public string bugName;

    public bool isRare = false;

    public float walkSpeed; // how fast it normally moves

    public float wonderDistance; // how far it will wonder on its own

    public float idleTimer; // time in between walking around

    public float runSpeed; // how fast it runs

    public float runProximity; // how close they player must be for it to run away

    public GameObject[] hidingSpots; // list of positions it can run to

    bool idle = true; // if its not running
    float time; // used for timing
    NavMeshAgent nav; // the NavMeshAgent attached to the bug

    Transform player;

    BugSpawner2 bS2;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        time = Random.Range(2f, 3.5f); // so that each bug is on their own idle times, otherwise they would all move at once.
        
        nav.speed = walkSpeed;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        hidingSpots = GameObject.FindGameObjectsWithTag("HidingSpot");

        bS2 = GameObject.FindGameObjectWithTag("BugSpawner").GetComponent<BugSpawner2>();
    }

    
    void Update()
    {

        time += Time.deltaTime;

        if (idle) // if allowed to idle
        {
            while (time >= idleTimer) // while the time is greater than their idle time
            {
                nav.destination = IdleWalk(); // set destination of nav mesh agent to random position
            }
        }

        //print(Vector3.Distance(player.position, transform.position));

        if(Vector3.Distance(player.position, transform.position) <= runProximity && idle == true)
        {
            //print("AI Running");

            idle = false;

            nav.speed = runSpeed; // make the bug run from player
            nav.destination = GetHidingSpot().position;
        }


        if(idle == false && transform.position.x == nav.destination.x && transform.position.z == nav.destination.z)
        {
            DestroyBug();
        }



    }


    Vector3 IdleWalk() // chooses a random position to walk to
    {
        //print("AI Walking");

        time = 0;

        Vector3 randomDirection = Random.insideUnitSphere * wonderDistance; // sets a random point in a circle with the radius of walkradius

        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, wonderDistance, 1); // selects position on a navmesh

        return hit.position;


    }


    public void DestroyBug()
    {
        bS2.bugsSpawned--;

        Destroy(this.gameObject); // might need to be changed later to have them transform somewhere else instead of destroy to save processing power
    }


    Transform GetHidingSpot() // selects a random hiding spot for them to run to.
    {
        int randpos = Random.Range(0, hidingSpots.Length);
        return hidingSpots[randpos].GetComponent<Transform>();
    }


}
