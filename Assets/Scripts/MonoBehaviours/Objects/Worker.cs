using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Worker : Unit {
    [Header("Properties")]
    public float speed;
    [Space]
    public int gatherYield;
    public float gatherDelay;
    public float range;

    void OnValidate() 
    {
        abilities = new List<Ability>();
        abilities.Add(new MoveAbility(this, speed));
        abilities.Add(new GatherAbility(this, gatherYield, gatherDelay, range));
    }
}