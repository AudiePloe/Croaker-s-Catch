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

    [Header("BugIcons")]
    public FlipSprite LadyBug;
    public FlipSprite Moth;
    public FlipSprite Jbeetle;
    public FlipSprite Rhino;
    public FlipSprite Dragonfly;
    public FlipSprite Butterfly;
    public FlipSprite Bee;
    public FlipSprite Scorpian;
    public FlipSprite Firefly;
    public FlipSprite Spider;
    public FlipSprite Snail;



    void Awake()
    {
        
        for(int i = 0; i < 12; i++) // run for every bug in game to make sure UI is up to date
        {
            checkAlerts();
        }

        if(GameDataStatic.bugsCaught == 0)
        {
            resetIcons();
        }



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
       (string, string) alert = GameDataStatic.sendAlert();

        // area alerts ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        if(alert.Item1 == "NONE") // if none then stop
        {
            return;
        }

        joernalAlert = true;

        if(alert.Item1 == "FOREST")
        {
            forestAlert = true;
        }

        if (alert.Item1 == "CAVE")
        {
            caveAlert = true;
        }

        // bug alerts ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        if (alert.Item2 == "ladybug")
        {
            LadyBug.SwapPic();
        }

        if (alert.Item2 == "moth")
        {
            Moth.SwapPic();
        }

        if (alert.Item2 == "jewel")
        {
            Jbeetle.SwapPic();
        }

        if (alert.Item2 == "rhino")
        {
            Rhino.SwapPic();
        }

        if (alert.Item2 == "dragon")
        {
            Dragonfly.SwapPic();
        }

        if (alert.Item2 == "butter")
        {
            Butterfly.SwapPic();
        }

        if (alert.Item2 == "bee")
        {
            Bee.SwapPic();
        }

        if (alert.Item2 == "scorp")
        {
            Scorpian.SwapPic();
        }

        if (alert.Item2 == "fire")
        {
            Firefly.SwapPic();
        }

        if (alert.Item2 == "spider")
        {
            Spider.SwapPic();
        }

        if (alert.Item2 == "snail")
        {
            Snail.SwapPic();
        }





        return;
    }
    

    void resetIcons()
    {
        LadyBug.resetImages();
        Moth.resetImages();
        Jbeetle.resetImages();
        Rhino.resetImages();
        Dragonfly.resetImages();
        Butterfly.resetImages();
        Bee.resetImages();
        Scorpian.resetImages();
        Firefly.resetImages();
        Spider.resetImages();
        Snail.resetImages();
    }


}
