using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{
    public GameObject loadingScreen;

    public Image slider;
    public Text progressText;




    private void OnEnable()
    {
        //Only specifying the sceneName or SceneBuildIndex will load the Scene with the Single mode
        //SceneManager.LoadScene("ForestLevel", LoadSceneMode.Single);

        StartCoroutine(LoadAsynch("ForestLevel"));

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




}
