using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner2 : MonoBehaviour
{

    public List<GameObject> bugList;

    public List<Transform> bugSpawns;

    public int maxBugsSpawned;

    public float spawnRate;

    float time = 0;
    public int bugsSpawned;


    void Start()
    {
        
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
        return bugSpawns[Random.Range(0, bugSpawns.Count)].position;
    }

    GameObject GetBug()
    {
        print("GotBug");
        return bugList[Random.Range(0, bugList.Count)];
    }

}
