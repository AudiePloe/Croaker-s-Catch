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
        
        if(joernalAlert) // if any bug is cought
        {
            iconAlert.SetActive(true);
            joernalAlertIcon.SetActive(true);
        }

        if(forestAlert) // if a bug belonging to the forest is cought
        {
            forestAlertIcon.SetActive(true);
        }

        if (caveAlert) // if a bug belonging to the cave is cought
        {
            caveAlertIcon.SetActive(true);
        }


        if(forestTrigger.activeInHierarchy) // when the player opens the page remove the alerts
        {
            iconAlert.SetActive(false);
            joernalAlertIcon.SetActive(false);
            forestAlertIcon.SetActive(false);

            joernalAlert = false;
            forestAlert = false;

        }


        if (caveTrigger.activeInHierarchy) // when the player opens the page remove the alerts
        {
            iconAlert.SetActive(false);
            joernalAlertIcon.SetActive(false);
            caveAlertIcon.SetActive(false);

            joernalAlert = false;
            caveAlert = false;

        }


    }

    public void checkAlerts() // check if any bugs have been caught for the first time.
    {
       string alert = GameDataStatic.sendAlert();

        if(alert == "NONE") // if none then stop
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
