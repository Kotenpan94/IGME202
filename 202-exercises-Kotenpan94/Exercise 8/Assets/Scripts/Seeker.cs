using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    public Fleer fleeObject;
    protected override void CalcSteeringForce()
    {
        Seek(fleeObject.physicsObject.Position);
    }
}
