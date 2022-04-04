using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSView : MonoBehaviour
{
    [Header("CameraSettings")]
    public GameObject playerModel;
    public PlayerController PC;
    public GameObject thirdPCamera;
    public GameObject firstPCamera;
    Transform FPC;
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    public bool isAiming = false;

    [Header("NetGunSettings")]
    public GameObject crosshairs;
    public Rigidbody net;
    public Transform netGunBarrel;
    public float netSpeed;
    public float fireRate;
    float time = 10f;

    void Start()
    {
        playerModel.SetActive(true);
        crosshairs.SetActive(false);
        FPC = firstPCamera.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(Input.GetKey(KeyCode.Mouse1))
        {
            isAiming = true;
            PC.canMove = false;
            thirdPCamera.SetActive(false);
            firstPCamera.SetActive(true);

            playerModel.SetActive(false);
            crosshairs.SetActive(true);

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            FPC.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            isAiming = false;
            PC.canMove = true;
            thirdPCamera.SetActive(true);
            firstPCamera.SetActive(false);
            crosshairs.SetActive(false);
            playerModel.SetActive(true);
        }


        if(isAiming)
        {
            if(Input.GetKey(KeyCode.Mouse0) && time >= fireRate)
            {
                Rigidbody netClone = (Rigidbody)Instantiate(net, netGunBarrel.position, netGunBarrel.rotation);
                netClone.GetComponent<Rigidbody>().AddForce(netGunBarrel.forward * netSpeed);

                time = 0f;
            }
        }

        
    }
}
