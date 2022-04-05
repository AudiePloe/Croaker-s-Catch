using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private void Update()
    {
        Time.timeScale = 1.0f;
    }
    public void playGame()
    {
        SceneManager.LoadScene("ForestLevel");
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
