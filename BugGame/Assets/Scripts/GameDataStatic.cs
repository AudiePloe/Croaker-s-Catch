using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameDataStatic
{
    //Overall bugs caught ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public static int bugsCaught    { get; set; }

    // Specific Bugs caught ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public static int moths         { get; set; }
    public static int jewelBeetle   { get; set; }
    public static int firefly       { get; set; }
    public static int dragonfly     { get; set; }
    public static int ladybug       { get; set; }
    public static int rhinobeetle   { get; set; }
    public static int snail         { get; set; }
    public static int scorpion      { get; set; }
    public static int spider        { get; set; }
    public static int bee           { get; set; }
    public static int butterfly     { get; set; }



    // Game data ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public static float gameVolume = 1;


    // journal system ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // bug alerts ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~    

    static bool mothAlert = false;
    static bool jewelAlert = false;
    static bool fireflyAlert = false;
    static bool dragonflyAlert = false;
    static bool ladybugAlert = false;
    static bool rhinoAlert = false;
    static bool snailAlert = false;
    static bool scorpionAlert = false;
    static bool spiderAlert = false;
    static bool beeAlert = false;
    static bool butterflyAlert = false;



    public static (string, string) sendAlert() // checks if any new bugs have been caught, if so, returns the biome in which they are found in.
    {

        //The Forest: Ladybug, Moth, Jewel Beetle, Rhino , dragonfly, Butterfly, bee

        //Cave bugs inside: Psudeoscorpion, Firefly, Spider, Snail

        //Flower Level Bugs: Ladybug, Bee, Moth (flower not confirmed)



        // forest hub bugs ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        if (ladybug > 0 && ladybugAlert == false)
        {
            ladybugAlert = true;
            return ("FOREST", "ladybug");
        }

        if (moths > 0 && mothAlert == false)
        {
            mothAlert = true;
            return ("FOREST", "moth");
        }

        if (jewelBeetle > 0 && jewelAlert == false)
        {
            jewelAlert = true;
            return ("FOREST", "jewel");
        }
        if (rhinobeetle > 0 && rhinoAlert == false)
        {
            rhinoAlert = true;
            return ("FOREST", "rhino");
        }

        if (dragonfly > 0 && dragonflyAlert == false)
        {
            dragonflyAlert = true;
            return ("FOREST", "dragon");
        }

        if (butterfly > 0 && butterflyAlert == false)
        {
            butterflyAlert = true;
            return ("FOREST", "butter");
        }

        if (bee > 0 && beeAlert == false)
        {
            beeAlert = true;
            return ("FOREST", "bee");
        }



        // cave bugs ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        if (scorpion > 0 && scorpionAlert == false)
        {
            scorpionAlert = true;
            return ("CAVE", "scorp");
        }

        if (firefly > 0 && fireflyAlert == false)
        {
            fireflyAlert = true;
            return ("CAVE", "fire");
        }

        if (spider > 0 && spiderAlert == false)
        {
            spiderAlert = true;
            return ("CAVE", "spider");
        }

        if (snail > 0 && snailAlert == false)
        {
            snailAlert = true;
            return ("CAVE", "snail");
        }


        //flower bugs ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~







        return ("NONE", "NONE"); // if none were caught
    }


    public static void resetParameters()
    {
        mothAlert = false;
        jewelAlert = false;
        fireflyAlert = false;
        dragonflyAlert = false;
        ladybugAlert = false;
        rhinoAlert = false;
        snailAlert = false;
        scorpionAlert = false;
        spiderAlert = false;
        beeAlert = false;
        butterflyAlert = false;



        bugsCaught = 0;
        moths = 0;
        jewelBeetle = 0;
        firefly = 0;
        dragonfly = 0;
        ladybug = 0;
        rhinobeetle = 0;
        snail = 0;
        scorpion = 0;
        spider = 0;
        bee = 0;
        butterfly = 0;


    }





}
