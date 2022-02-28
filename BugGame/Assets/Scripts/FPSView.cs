using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSView : MonoBehaviour
{
    public GameObject thirdPersonController;
    public GameObject firstPersonController;

    void Start()
    {
        thirdPersonController.SetActive(true);
        firstPersonController.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            firstPersonController.transform.position = thirdPersonController.transform.position;


            thirdPersonController.SetActive(false);
            firstPersonController.SetActive(true);
        }
        else
        {
            thirdPersonController.transform.position = firstPersonController.transform.position;

            thirdPersonController.SetActive(true);
            firstPersonController.SetActive(false);
        }
    }
}
