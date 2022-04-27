using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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
    public bool canAim = true;
    public float minCameraAngle;
    public float maxCameraAngle;


    [Header("NetGunSettings")]
    public GameObject crosshairs;
    public GameObject cooldownIndicator;
    public Rigidbody net;
    public Transform netGunBarrel;
    public float netSpeed;
    public float fireRate;
    public AudioSource shootGun;
    float time = 10f;

    void Start()
    {
        cooldownIndicator.SetActive(false);
        playerModel.SetActive(true);
        crosshairs.SetActive(false);
        FPC = firstPCamera.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canAim && PC.isGrounded)
        {
            time += Time.deltaTime;

            if (Input.GetKey(KeyCode.Mouse1))
            {
                isAiming = true;
                PC.canMove = false;
                thirdPCamera.SetActive(false);
                firstPCamera.SetActive(true);

                playerModel.SetActive(false);
                crosshairs.SetActive(true);

                float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; // get mouse postions with movement
                float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

                xRotation -= mouseY;
                FPC.localRotation = Quaternion.Euler(Mathf.Clamp(xRotation, minCameraAngle, maxCameraAngle), 0f, 0f); // apply rotation to player controller

                transform.Rotate(Vector3.up * mouseX); // rotate the camera


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


            if (isAiming)
            {
                if (Input.GetKey(KeyCode.Mouse0) && time >= fireRate)
                {
                    Rigidbody netClone = (Rigidbody)Instantiate(net, netGunBarrel.position, netGunBarrel.rotation);
                    netClone.GetComponent<Rigidbody>().AddForce(netGunBarrel.forward * netSpeed);

                    shootGun.Play();

                    time = 0f;

                }
            }


            if(time <= fireRate)
            {
                cooldownIndicator.SetActive(true);

                cooldownIndicator.GetComponent<Image>().fillAmount = time / fireRate;

            }
            else
            {
                cooldownIndicator.SetActive(false);
            }



        }
    }
}
