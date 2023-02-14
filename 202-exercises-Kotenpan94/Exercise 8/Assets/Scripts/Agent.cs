using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof (PhysicsObject))]

public abstract class Agent : MonoBehaviour
{
    public PhysicsObject physicsObject;

    public float maxSpeed = 5f;
    public float maxForce = 5f;

    private Vector3 totatlForce = Vector3.zero;

    private void Awake()
    {
        if (physicsObject == null)
        {
            physicsObject = GetComponent<PhysicsObject>();
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        CalcSteeringForce();

        totatlForce = Vector3.ClampMagnitude(totatlForce, maxForce);

        physicsObject.ApplyForce(totatlForce);

        totatlForce = Vector3.zero;
    }

    protected abstract void CalcSteeringForce();
    
    protected void Seek (Vector3 targetPosition, float weight = 1f)
    {
        //Calculate desired Velocity - Where we want to go
        Vector3 desiredVelocity = targetPosition - physicsObject.Position;
        //Set Desired Velocity magnitude to max speed
        desiredVelocity = desiredVelocity.normalized * maxSpeed;
        //Calc seek steering force
        Vector3 seekingForce = desiredVelocity - physicsObject.Velocity;
        //Apply seek steering force
        totatlForce += seekingForce * weight;
    }
    protected void Flee (Vector3 targetPosition, float weight = 1f)
    {
        Vector3 desiredVelocity = physicsObject.Position - targetPosition;

        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        Vector3 fleeingForce = desiredVelocity - physicsObject.Velocity;

        totatlForce += fleeingForce * weight;
    }
}
