using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    public bool isCurrentlyColliding = false;
    [HideInInspector]
    public List<CollidableObject> collisions = new List<CollidableObject>();

    public Vector2 boundingBox = Vector2.one;
    public float radius = 1f;

    public SpriteRenderer spriteStored;
    //Using get shortcut to assign
    public float maxX  => spriteStored.bounds.max.x;
    public float maxY => spriteStored.bounds.max.y;
    public float minX => spriteStored.bounds.min.x;
    public float minY => spriteStored.bounds.min.y;
    public float rad => spriteStored.bounds.extents.magnitude;
    public Vector3 center => spriteStored.bounds.center;
    public Vector3 size => spriteStored.bounds.size;


    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        //If currently colliding, turn red
        if (isCurrentlyColliding)
        {
            spriteStored.color = Color.red;
        }
        else
        {
            spriteStored.color = Color.white;

        }

    }
    //Adds to a list that stores the collisions and makes isCurrentlyColliding true
    public void AddCollision (CollidableObject other)
    {
        isCurrentlyColliding = true;
        collisions.Add(other);
    }
    //Resets the collisions list and bool
    public void ResetCollision()
    {
        isCurrentlyColliding = false;
        collisions.Clear();
    }
    //Gizmos function - Using Selected to specifically check the sprite I want to check
    private void OnDrawGizmosSelected()
    {
        if (isCurrentlyColliding)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;

        }
/*        Gizmos.DrawWireCube(transform.position, boundingBox);
*/
        Gizmos.DrawWireSphere(transform.position, radius);

    }
}
