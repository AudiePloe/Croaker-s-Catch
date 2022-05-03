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
    public GameObject journal;

    [Header("BugIcons")]
    public FlipSprite LadyBug;
    public FlipSprite Moth;
    public FlipSprite Jbeetle;
    public FlipSprite Rhino;
    public FlipSprite Dragonfly;
    public FlipSprite Butterfly;
    public FlipSprite Bee;
    public FlipSprite scorpion;
    public FlipSprite Firefly;
    public FlipSprite Spider;
    public FlipSprite Snail;



    void Awake()
    {

        UpdateIcons();


        if(GameDataStatic.bugsCaught == 0)
        {
            resetIcons();
        }


    }

    // Update is called once per frame
    void Update()
    {


        if (!journal.activeInHierarchy)
        {
            forestTrigger.SetActive(false);
            caveTrigger.SetActive(false);
        }


        
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
            scorpion.SwapPic();
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
    

    void UpdateIcons()
    {
        if(GameDataStatic.ladybug > 0)
        {
            LadyBug.SwapPic();
        }

        if (GameDataStatic.moths > 0)
        {
            Moth.SwapPic();
        }

        if (GameDataStatic.jewelBeetle > 0)
        {
            Jbeetle.SwapPic();
        }

        if (GameDataStatic.rhinobeetle > 0)
        {
            Rhino.SwapPic();
        }

        if (GameDataStatic.dragonfly > 0)
        {
            Dragonfly.SwapPic();
        }

        if (GameDataStatic.butterfly > 0)
        {
            Butterfly.SwapPic();
        }

        if (GameDataStatic.bee > 0)
        {
            Bee.SwapPic();
        }

        if (GameDataStatic.scorpion > 0)
        {
            scorpion.SwapPic();
        }

        if (GameDataStatic.firefly > 0)
        {
            Firefly.SwapPic();
        }

        if (GameDataStatic.spider > 0)
        {
            Spider.SwapPic();
        }

        if (GameDataStatic.snail > 0)
        {
            Snail.SwapPic();
        }


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
        scorpion.resetImages();
        Firefly.resetImages();
        Spider.resetImages();
        Snail.resetImages();
    }


}
