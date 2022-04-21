using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject loadingScreen;

    public Slider slider;
    public Text progressText;

    IEnumerator LoadAsynch (string level)
    {
        loadingScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }

        loadingScreen.SetActive(false);
    }


    private void Update()
    {
        Time.timeScale = 1.0f;
    }
    public void playGame()
    {
        

        StartCoroutine(LoadAsynch("ForestLevel"));


        //SceneManager.LoadScene("ForestLevel");
    }

    public void exitGame()
    {
        Application.OpenURL("https://forms.gle/XmoEHsqZ658m1due7");
        Debug.Log("Quit!!!!!!!! >:0");
        Application.Quit();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void creditsMenu()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    public void instructMenu()
    {
        SceneManager.LoadScene("HowToPlayMenu");
    }

    public void forestMenu()
    {
        SceneManager.LoadScene("ForestPage");
    }

    public void journalMenu()
    {
        SceneManager.LoadScene("JournalTestScene");
    }

    public void caveMenu()
    {
        SceneManager.LoadScene("CavePage");
    }
}
