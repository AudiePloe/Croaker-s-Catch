using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    Resolution[] resolutions;

    public Dropdown resolutionDropdown;
    public Dropdown graphicsDropdown;


    private void Awake()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResIndex = 0;


        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;

            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResIndex = i;
                }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue();


        graphicsDropdown.value = QualitySettings.GetQualityLevel();

    }


    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }


    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
