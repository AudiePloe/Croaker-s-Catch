using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{
    private void OnEnable()
    {
        //Only specifying the sceneName or SceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene("ForestLevel", LoadSceneMode.Single);
    }
}
