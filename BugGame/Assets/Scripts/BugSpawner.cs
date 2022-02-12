// If someone can help me on how I can make a decent spawning system, that would be appreciated.
// I haven't used Unity and coded in C# in 5 years, so it would be appreciated if someone can give me
// a headstart to go back to the level where I was back in 2017, because at this moment I'm just lost.
// - Jason Martinez

// This is a placeholder spawner, do not use this. I plan on rewritting it soon.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public GameObject bug;
    public int xPosition;
    public int zPosition;
    public int bugsSpawned;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnBug());
    }

    IEnumerator spawnBug()
    {
        while(bugsSpawned < 15)
        {
            xPosition = Random.Range(100, 890);
            zPosition = Random.Range(100, 830);
            Instantiate(bug, new Vector3(xPosition, 25, zPosition), Quaternion.identity);
            yield return new WaitForSeconds(5);
            bugsSpawned += 1;
        }
    }
}
