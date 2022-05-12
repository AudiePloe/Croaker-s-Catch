// Audie Ploe

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public bool showSurvey;
    public GameObject journalObjects;


    bool playerWin = false;
    public static bool GameIsPaused = false;


    public GameObject pauseMenuUI;
    public UnityEvent OnPause;
    public UnityEvent OnResume;


    FPSView playerFPS;
    PlayerCatch playerCatch;
    PlayerController playerController;

     void Start()
    {
        playerFPS = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSView>();
        playerCatch = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCatch>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Update()
    {

     if(Input.GetKeyDown(KeyCode.Escape) && !playerWin)
        {

            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        playerCatch.canSwing = true;
        journalObjects.SetActive(false);
        playerFPS.canAim = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        OnResume.Invoke();
        GameIsPaused = false;
    }

    void Pause ()
    {
        playerCatch.canSwing = false;
        playerFPS.canAim = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        OnPause.Invoke();
        GameIsPaused = true;
    }

    public void pauseToWin()
    {
        playerWin = true;
        playerCatch.canSwing = false;
        playerFPS.canAim = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pauseMenuUI.SetActive(false);
        OnPause.Invoke();
        GameIsPaused = true;
        playerController.canMove = false;
    }

    public void resumeFromWin()
    {
        playerWin = false;

        playerCatch.canSwing = true;
        journalObjects.SetActive(false);
        playerFPS.canAim = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        OnResume.Invoke();
        GameIsPaused = false;

        playerFPS.StopAiming();
        playerController.canMove = true;

    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("CreditsMenu");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        if(showSurvey)
            Application.OpenURL("https://forms.gle/XmoEHsqZ658m1due7");


        Debug.Log("QuitGAME ;]");
        Application.Quit();
    }


}
