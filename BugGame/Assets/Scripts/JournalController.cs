using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalController : MonoBehaviour
{
    bool joernalAlert;
    bool forestAlert;
    bool caveAlert;

    [Header("Alert Icons")]
    public GameObject iconAlert;
    public GameObject joernalAlertIcon;
    public GameObject forestAlertIcon;
    public GameObject caveAlertIcon;

    [Header("Alert Triggers")]
    public GameObject forestTrigger;
    public GameObject caveTrigger;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(joernalAlert)
        {
            iconAlert.SetActive(true);
            joernalAlertIcon.SetActive(true);
        }

        if(forestAlert)
        {
            forestAlertIcon.SetActive(true);
        }

        if (caveAlert)
        {
            caveAlertIcon.SetActive(true);
        }


        if(forestTrigger.activeInHierarchy)
        {
            iconAlert.SetActive(false);
            joernalAlertIcon.SetActive(false);
            forestAlertIcon.SetActive(false);

            joernalAlert = false;
            forestAlert = false;

        }


        if (caveTrigger.activeInHierarchy)
        {
            iconAlert.SetActive(false);
            joernalAlertIcon.SetActive(false);
            caveAlertIcon.SetActive(false);

            joernalAlert = false;
            caveAlert = false;

        }


    }

    public void checkAlerts()
    {
       string alert = GameDataStatic.sendAlert();

        if(alert == "NONE")
        {
            return;
        }

        joernalAlert = true;

        if(alert == "FOREST")
        {
            forestAlert = true;
        }

        if (alert == "CAVE")
        {
            caveAlert = true;
        }


        return;
    }
    




}
