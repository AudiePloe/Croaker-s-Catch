using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner2 : MonoBehaviour
{

    public List<GameObject> bugList;

    public List<GameObject> rareBugsList;

    public List<Transform> bugSpawns;

    public int maxBugsSpawned;

    public float spawnRate;

    float time = 0;
    public int bugsSpawned;

    Transform player;

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

        
    }


    void SpawnBug()
    {
        GameObject newBug = (GameObject)Instantiate(GetBug(), GetSpawnPoint(), Quaternion.identity);
        bugsSpawned++;
    }


    Vector3 GetSpawnPoint()
    {
        Vector3 spawnPoint = bugSpawns[Random.Range(0, bugSpawns.Count)].position;

        while (Vector3.Distance(spawnPoint, player.position) <= 20)
        {
            spawnPoint = bugSpawns[Random.Range(0, bugSpawns.Count)].position;
        }
        return spawnPoint;
    }

    GameObject GetBug()
    {
       // print("GotBug");
        return bugList[Random.Range(0, bugList.Count)];
    }

}
