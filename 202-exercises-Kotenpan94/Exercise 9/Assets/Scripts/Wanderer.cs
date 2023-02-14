using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agent
{
    public float wanderWeight = 1f;

    [Min(1f)]
    public float stayInBoundsWeight = 3f;
    protected override void CalcSteeringForce()
    {
        Wander(wanderWeight);
        StayInBounds(stayInBoundsWeight);
    }
}
