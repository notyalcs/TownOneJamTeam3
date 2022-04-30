using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comp_AllyUnit : Comp_UnitInfo
{

    [Header("Ally Unit Info")]
    [SerializeField] public Constants.AlienTypes Species;
    [SerializeField] public float Cooldown;
    [SerializeField] public float Cost;

}
