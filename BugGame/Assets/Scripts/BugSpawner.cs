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
