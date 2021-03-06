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
    public static int Levels = 3;
    public static int StartNodes = 3;
    public static float StartHP = 100f;
    public static float StartSpeed = 0.5f;
    public static float StartArmour = 0f;
    public static int StartUpgrades = 2;
    public static float StartMoney = 100f;
    public static float WaitTime = 5f;
}
