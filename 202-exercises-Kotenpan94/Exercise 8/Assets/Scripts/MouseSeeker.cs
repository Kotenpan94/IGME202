using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class MouseSeeker : Agent
{
    protected override void CalcSteeringForce()
    {
        //Seek towards Mouse Pos
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0f;

        Flee(mousePosition);
    }
}
