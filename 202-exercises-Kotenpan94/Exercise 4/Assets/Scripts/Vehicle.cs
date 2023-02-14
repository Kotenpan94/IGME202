using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vehicle : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 6f;
    public Vector2 direction = Vector2.right;
    public Vector2 velocity = Vector2.zero;
    private Vector2 movementInput;
    private float width;
    private float height;
    //Creating a camera field 
    Camera cam;
     
    void Start()
    { 
        //Intializations
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
       

        direction = movementInput;
        //Velocity is our direction * speed * (deltaTime)
        velocity = speed * direction * Time.deltaTime;
        //Update position by adding velocity
        transform.position += (Vector3)velocity;


        if (direction != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        }

        //Checks Right Side
        if (transform.position.x > width/2)
        {

            transform.position = new Vector3(-width/2, transform.position.y, 0);

        }
        //Checks Left Side
        else if (transform.position.x < -width / 2)
        {
            transform.position = new Vector3(width / 2, transform.position.y, 0);

        }
        //Checks Top of Screen
        if (transform.position.y > height / 2)
        {
            transform.position = new Vector3(transform.position.x, -height/2, 0);

        }
        //Checks Bottom of Screen
        else if (transform.position.y < -height / 2)
        {
            transform.position = new Vector3(transform.position.x, height/2, 0);

        }

        
        

    }
    public void OnMove(InputAction.CallbackContext moveContext)
    {
        movementInput = moveContext.ReadValue<Vector2>();
    }
}
