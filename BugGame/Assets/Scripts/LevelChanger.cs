using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public string levelToChangeTo; // the scene you want to change to



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(levelToChangeTo);
        }
    }


}
