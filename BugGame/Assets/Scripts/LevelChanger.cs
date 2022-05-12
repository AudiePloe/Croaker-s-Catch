// Audie Ploe

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;




public class LevelChanger : MonoBehaviour
{
    public string levelToChangeTo; // the scene you want to change to
    public GameObject loadingScreen;

    public Image slider;
    public Text progressText;

    //PlayerPositionManager PPM;
    

    void Start()
    {
        //PPM = GameObject.Find("GameManager").GetComponent<PlayerPositionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator LoadAsynch(string level) // loads level asynch so that loading screen can show progress
    {
        loadingScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.fillAmount = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }

        loadingScreen.SetActive(false);
    }




    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //PPM.SceneString = SceneManager.GetActiveScene().name;
            StartCoroutine(LoadAsynch(levelToChangeTo));
        }
    }
}
