// Audie Ploe

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BugScript : MonoBehaviour
{
    public bool isStationary;

    public GameObject canvasObject; // used for exlamation mark

    public AudioSource skitterSound;

    public GameObject lightSource; // used for showing player is in range

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

    PlayerController playerController;
    Transform player;
    float runProxy;

    public BugSpawner2 bS2;
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        time = Random.Range(2f, 3.5f); // so that each bug is on their own idle times, otherwise they would all move at once.
        
        nav.speed = walkSpeed;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerController = player.GetComponent<PlayerController>();

        hidingSpots = GameObject.FindGameObjectsWithTag("HidingSpot");

        bS2 = GameObject.FindGameObjectWithTag("BugSpawner").GetComponent<BugSpawner2>();
    }

    
    void Update()
    {

        if (!isStationary)
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


            if (playerController.isCrouched)
            {
                runProxy = runProximity / 2;
            }
            else
                runProxy = runProximity;

            if (Vector3.Distance(player.position, transform.position) <= runProxy && idle == true)
            {
                //print("AI Running");

                canvasObject.SetActive(true);

                skitterSound.Play();

                idle = false;

                nav.speed = runSpeed; // make the bug run from player
                nav.destination = GetHidingSpot().position;
            }


            if (idle == false && transform.position.x == nav.destination.x && transform.position.z == nav.destination.z)
            {
                DestroyBug();
            }

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
        Transform firstClosest = hidingSpots[0].transform;
        Transform secondClosest = hidingSpots[1].transform;
        Transform thirdClosest = hidingSpots[2].transform;

        for (int i = 0; i < hidingSpots.Length; i++)
        {
            if(Vector3.Distance(transform.position, hidingSpots[i].transform.position) < Vector3.Distance(transform.position, firstClosest.position))
            {
                firstClosest = hidingSpots[i].transform;
                continue;
            }

            if (Vector3.Distance(transform.position, hidingSpots[i].transform.position) < Vector3.Distance(transform.position, secondClosest.position))
            {
                secondClosest = hidingSpots[i].transform;
                continue;
            }

            if (Vector3.Distance(transform.position, hidingSpots[i].transform.position) < Vector3.Distance(transform.position, thirdClosest.position))
            {
                thirdClosest = hidingSpots[i].transform;
                continue;
            }

        }

        List<Transform> closestSpots = new List<Transform>();

        closestSpots.Add(firstClosest);
        closestSpots.Add(secondClosest);
        closestSpots.Add(thirdClosest);


        int randpos = Random.Range(1, closestSpots.Count);
        return closestSpots[randpos];
    }


}
