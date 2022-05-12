using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    public GameObject levelChanger;


    public void skip()
    {
        //SceneManager.LoadScene("ForestLevel");

        levelChanger.SetActive(true);
    }
}
