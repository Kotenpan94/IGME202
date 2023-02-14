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

    private float wanderAngle = 0f;

    public float maxWanderAngle = 45f;

    public float maxWanderChangePerSecond = 10f;

   

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

    protected void Wander (float weight = 1f)
    {
        //Update the angle of our current wanderer
        float maxWanderChange = maxWanderChangePerSecond * Time.deltaTime;
        wanderAngle += Random.Range(-maxWanderChange, maxWanderChange);

        wanderAngle = Mathf.Clamp(wanderAngle, -maxWanderAngle, maxWanderAngle);
        //Get a Position that is defined by that wanderer angle
        Vector3 wanderTarget = Quaternion.Euler(0, 0, wanderAngle) * physicsObject.Direction.normalized + physicsObject.Position;
        Seek(wanderTarget, weight);
    }
    protected void StayInBounds (float weight = 2f)
    {
        Vector3 futurePosition = GetFuturePosition(1.75f);

        if (futurePosition.x >= physicsObject.CameraSize.x || futurePosition.x <= -physicsObject.CameraSize.x || futurePosition.y >= physicsObject.CameraSize.y || futurePosition.y <= -physicsObject.CameraSize.y)
        {
            
            Seek(Vector3.zero, weight);
        }
    }

    public Vector3 GetFuturePosition (float timeToLookAhead = 1f)
    {
        return physicsObject.Position + physicsObject.Velocity * timeToLookAhead;
    }

}
