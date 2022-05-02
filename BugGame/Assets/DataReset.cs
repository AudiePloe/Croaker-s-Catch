using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReset : MonoBehaviour
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
