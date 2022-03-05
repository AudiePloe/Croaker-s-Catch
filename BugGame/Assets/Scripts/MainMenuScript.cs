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
}
