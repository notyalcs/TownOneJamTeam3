using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public static float AlienTypesLength = 6.0f;
    public enum AlienTypes
    {
        TRAIN,
        HAMSTER,
        FAST,
        ARMOUR,
        STRONG,
        TANKY,
        RANGED
    }
    public static float PlanetNamesLength = 3;
    public enum PlanetNames
    {
        Vastel,
        Sahr,
        Corus,
        Praera,
        Seniru,
        Than,
        Lontos,
        Earth
    }
    public static int Levels = 6;
    public static int StartNodes = 3;
}
