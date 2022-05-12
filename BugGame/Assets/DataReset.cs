using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReset : MonoBehaviour // resets the game data when user goes to main menu
{
    // Start is called before the first frame update
    void Awake()
    {
        GameDataStatic.resetParameters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
