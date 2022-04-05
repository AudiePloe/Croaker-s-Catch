using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public bool showSurvey;


    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public UnityEvent OnPause;
    public UnityEvent OnResume;
    FPSView playerFPS;

     void Start()
    {
        playerFPS = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSView>();


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Escape))
        {
            //Cursor.lockState = CursorLockMode.Confined;
            //Cursor.visible = true;
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
        playerFPS.canAim = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        OnPause.Invoke();
        GameIsPaused = true;
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
