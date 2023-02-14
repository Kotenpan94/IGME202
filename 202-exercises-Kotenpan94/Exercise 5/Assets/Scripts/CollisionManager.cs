using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    //Store all of collidable objects in scene
    public List<CollidableObject> collidableObjects = new List<CollidableObject>();
    public TextMesh textObj;
    public SpriteInfo sprit;

    public bool isCircleCollision = false;


    // Start is called before the first frame update
    void Start()
    {
        sprit = GetComponent<SpriteInfo>();
        //Calling switch to AABB to start the game out in that collision checking
        SwitchtToAABBCollision();
    }

    // Update is called once per frame
    void Update()
    {
        //Foreach loop runs in order to clear out all collisions at the start of each update
        foreach(CollidableObject collidableObject in collidableObjects)
        {
            //reset collision]
            collidableObject.ResetCollision();

        }

        //Check to see if they are colliding with any other objects and tell the objects what they're colliding with
        for (int i = 0; i < collidableObjects.Count; i++)
        {
            for (int j = i+1; j < collidableObjects.Count; j++)
            {
                if (isCircleCollision)
                {
                    //do circle collision check
                    if (CircleCollision(collidableObjects[i], collidableObjects[j]))
                    {
                        Debug.Log(collidableObjects[i].name);
                        collidableObjects[i].AddCollision(collidableObjects[j]);
                        collidableObjects[j].AddCollision(collidableObjects[i]);
                   
                    }


                }
                else
                {
                    //If AABB Collision method returns true from these two collidable objects then:
                    if (AABBCollision(collidableObjects[i], collidableObjects[j]))
                    {
                        Debug.Log(collidableObjects[i].name);
                        collidableObjects[i].AddCollision(collidableObjects[j]);
                        collidableObjects[j].AddCollision(collidableObjects[i]);

                    }
                }
            }
        }

    }
    //Method that checks for AABB Collision and returns true/false
    private bool AABBCollision(CollidableObject otherColliderA, CollidableObject otherColliderB)
    {
        //Check to see if this object A and the other object b, if they are colliding
        
        //First need to get a reference to bounds
        if (otherColliderB.minX < otherColliderA.maxX && otherColliderB.maxX > otherColliderA.minX && otherColliderB.maxY > otherColliderA.minY && otherColliderB.minY < otherColliderA.maxY)
        {
            return true;
        }
        else
        {
            return false;
        }

        
    }
    //Method that checks for Circle Collision and returns true/false

    private bool CircleCollision (CollidableObject otherColliderA, CollidableObject otherColliderB)
    {
        if (Vector3.Distance(otherColliderB.center, otherColliderA.center) < otherColliderA.radius + otherColliderB.radius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //Method that switches to circle collision and lets the player know what collision they are in
    public void SwitchtToCircleCollision()
    {
        isCircleCollision = true;
        textObj.text = "You are in Circle Collision currently, press B to switch";
        textObj.fontSize = 9;
    }
    //Method that switches to AABB collision and lets the player know what collision they are in
    public void SwitchtToAABBCollision()
    {
        isCircleCollision = false;
        textObj.text = "You are in AABB Collision currently, press C to switch";
        textObj.fontSize = 9;


    }

}
