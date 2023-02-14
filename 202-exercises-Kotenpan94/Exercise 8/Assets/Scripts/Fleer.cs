using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleer : Agent
{
    public Seeker seekObject;
    public Fleer fleeObject;
    private Vector3 minPosition;
    private Vector3 maxPosition;
    private void Start()
    {
        //Bottom left corner of camera
        minPosition = Camera.main.ScreenToWorldPoint(Vector3.zero);
        //Top right corner of camera
        maxPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }
    protected override void CalcSteeringForce()
    {
        //flee away from a given agent, set reference in Fleer
        
        Flee(seekObject.physicsObject.Position);

        //Teleport if it gets caught
    }
    protected override void Update()
    {
        base.Update();

        //Do circle collision check to see if seeker caught this object
        if (Vector3.Distance(seekObject.physicsObject.Center, fleeObject.physicsObject.Center) < seekObject.physicsObject.radius + fleeObject.physicsObject.radius)
        {
            Debug.Log("Collided!");
            Vector3 spawnPosition = new Vector3(Random.Range(minPosition.x,maxPosition.x), Random.Range(minPosition.y, maxPosition.y), 0f);
            transform.position = spawnPosition;

        }


        //If caught, teleport to a random position
    }
   
    
}
