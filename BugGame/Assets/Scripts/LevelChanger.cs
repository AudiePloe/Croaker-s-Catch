using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public string levelToChangeTo; // the scene you want to change to
    public GameObject loadingScreen;

    public Slider slider;
    public Text progressText;


    public string playerComeFrom;



    void Start()
    {

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
            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }

        loadingScreen.SetActive(false);
    }




    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            StartCoroutine(LoadAsynch(levelToChangeTo));
        }
    }


}
