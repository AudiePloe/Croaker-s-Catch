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
    public static int scorpian      { get; set; }
    public static int spider        { get; set; }
    public static int bee           { get; set; }
    public static int butterfly     { get; set; }



    // Game data ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public static float gameVolume = 1;


    // journal system ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    static bool mothAlert = false;
    static bool jewelAlert = false;
    static bool fireflyAlert = false;
    static bool dragonflyAlert = false;
    static bool ladybugAlert = false;
    static bool rhinoAlert = false;
    static bool snailAlert = false;
    static bool scorpianAlert = false;
    static bool spiderAlert = false;
    static bool beeAlert = false;
    static bool butterflyAlert = false;



    public static string sendAlert() // checks if any new bugs have been caught, if so, returns the biome in which they are found in.
    {

        //The Forest: Ladybug, Moth, Jewel Beetle, Rhino , dragonfly, Butterfly, bee

        //Cave bugs inside: Psudeoscorpian, Firefly, Spider, Snail

        //Flower Level Bugs: Ladybug, Bee, Moth (flower not confirmed)



        // forest hub bugs ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        if (ladybug > 0 && ladybugAlert == false)
        {
            ladybugAlert = true;
            return ("FOREST");
        }

        if (moths > 0 && mothAlert == false)
        {
            mothAlert = true;
            return ("FOREST");
        }

        if (jewelBeetle > 0 && jewelAlert == false)
        {
            jewelAlert = true;
            return ("FOREST");
        }
        if (rhinobeetle > 0 && rhinoAlert == false)
        {
            rhinoAlert = true;
            return ("FOREST");
        }

        if (dragonfly > 0 && dragonflyAlert == false)
        {
            dragonflyAlert = true;
            return ("FOREST");
        }

        if (butterfly > 0 && butterflyAlert == false)
        {
            butterflyAlert = true;
            return ("FOREST");
        }

        if (bee > 0 && beeAlert == false)
        {
            beeAlert = true;
            return ("FOREST");
        }



        // cave bugs ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        if (scorpian > 0 && scorpianAlert == false)
        {
            scorpianAlert = true;
            return ("CAVE");
        }

        if (firefly > 0 && fireflyAlert == false)
        {
            fireflyAlert = true;
            return ("CAVE");
        }

        if (spider > 0 && spiderAlert == false)
        {
            spiderAlert = true;
            return ("CAVE");
        }

        if (snail > 0 && snailAlert == false)
        {
            snailAlert = true;
            return ("CAVE");
        }


        //flower bugs ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~







        return ("NONE");
    }


}
