// Audie Ploe

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner2 : MonoBehaviour
{
    [Header("Spawnable Bugs")]

    public List<GameObject> bugList; // list of normal bugs to spawn
    public int maxBugsSpawned; // number of moving bugs spawned
    public float spawnRate; // rate at which they spawn
    public List<Transform> bugSpawns; // list of all spawnpoints in map



    [Header("Stationary bugs")]

    public List<GameObject> stationaryBugList; // list of bugs that dont move
    public int maxStationaryBugs; // max stationary bugs
    int stationaryBugsSpawned; // number of stationary bugs spawned



    [Header("Rare Bug")]

    public List<GameObject> rareBugList; // list of rate bugs
    public float rareBugChance; // chance that rare bug will spawn (out of 100)



    

    float time = 0;
    public int bugsSpawned; // number of bugs spawned

    Transform player; // used for reference to players position

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;


        if (bugsSpawned < maxBugsSpawned && time >= spawnRate)
        {
            SpawnBug();
            time = 0;
        }

        if (stationaryBugsSpawned < maxStationaryBugs)
        {
            getStationaryBug();
        }
        
    }


    void SpawnBug() // spawns bugs from lists available
    {

        if(rareBugChance > Random.Range(0f, 100f))
        {
            GameObject newRareBug = (GameObject)Instantiate(GetRareBug(), GetSpawnPoint(), Quaternion.identity);
            bugsSpawned++;
        } 
        else
        {
            GameObject newBug = (GameObject)Instantiate(GetBug(), GetSpawnPoint(), Quaternion.identity);
            bugsSpawned++;
        }

    }


    Vector3 GetSpawnPoint() // returns a random spawnpoint from list
    {
        Vector3 spawnPoint = bugSpawns[Random.Range(0, bugSpawns.Count)].position;

        while (Vector3.Distance(spawnPoint, player.position) <= 20)
        {
            spawnPoint = bugSpawns[Random.Range(0, bugSpawns.Count)].position;
        }
        return spawnPoint;
    }

    GameObject GetBug() // returns random bug from list
    {
       // print("GotBug");
        return bugList[Random.Range(0, bugList.Count)];
    }

    GameObject GetRareBug() // returns rare bug
    {
        // print("GotBug");
        return rareBugList[Random.Range(0, rareBugList.Count)];
    }


    void getStationaryBug() // sets random stationary bug active in game
    {
        stationaryBugsSpawned++;
        GameObject newBug = stationaryBugList[Random.Range(0, stationaryBugList.Count)];
        stationaryBugList.Remove(newBug);
        newBug.SetActive(true);

    }


}
