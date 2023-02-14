using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    [Header("Movement")]
    private Vector3 velocity;
    private Vector3 acceleration;
    private Vector3 direction;
    private Vector3 mousePosition;
    private Vector3 mousePositionWorld;
    //Holds vector 3 that contains the distance from mouse to the object
    private float mouseToObjectPosition;

    public Vector3 mousePos => mousePositionWorld;

    public float mass = 1f;
    public float frictionCoeff = 0.2f;
    public SpriteRenderer spriteSelected;
    [Header("Booleans")]
    public bool bounceOffWalls = false;
    public bool useGravity = false;
    public bool useFriction = false;

    public float radius = 1f;

    public Vector3 Center => spriteSelected.bounds.center;
    

    public Vector3 Velocity => velocity;
    public Vector3 Direction => direction;

    public Vector3 Position => transform.position;

    public Vector3 CameraSize => cameraSize;

    //Camera related field
    private Vector3 cameraSize;


    // Start is called before the first frame update
    void Start()
    {
        
        cameraSize.y = Camera.main.orthographicSize;
        cameraSize.x = cameraSize.y * Camera.main.aspect;

        direction = Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        //If statements for whether or not to use Gravity or Friction
        if (useGravity)
        {
            ApplyGravity(Physics.gravity);
        }
        if (useFriction)
        {
            ApplyFriction(frictionCoeff);
        }
        //Calculate new velocity based on the acceleration of the object
        velocity += acceleration * Time.deltaTime;
        //Calculate the new pos based on the velocity for this frame
        transform.position += velocity * Time.deltaTime;

        if (velocity.sqrMagnitude > Mathf.Epsilon)
        {
            //Store direction that object is moving in
            direction = velocity.normalized;
        }
        
        //Zero out acceleration for next frame
        acceleration = Vector3.zero;

        //Bounce method call
        if (bounceOffWalls)
        {
            Bounce();
        }

        transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
    }
    //Applies a given force to the acceleration
    public void ApplyForce (Vector3 force)
    {
        acceleration += (Vector3)force / mass;
    }
    //Takes in a param of how much friction to apply to an object(coefficient of friction)
    private void ApplyFriction (float coeff)
    {
        Vector3 friction = velocity * -1;
        friction.Normalize();
        friction = friction * coeff;

        ApplyForce(friction);
    }
    private void ApplyGravity (Vector3 gravityForce)
    {
        acceleration += gravityForce;
    }
    private void Bounce()
    {
        //If off screen change direction opposite of direction moving
        //Right side
        if (transform.position.x > cameraSize.x && velocity.x > 0)
        {
            velocity.x *= -1f;
        }
        if (transform.position.x < -cameraSize.x && velocity.x < 0)
        {
            velocity.x *= -1f;
        }
        if (transform.position.y > cameraSize.y && velocity.y > 0)
        {
            velocity.y *= -1f;
        }
        if (transform.position.y < -cameraSize.y && velocity.y < 0)
        {
            velocity.y *= -1f;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);

    }
}
