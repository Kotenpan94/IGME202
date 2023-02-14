using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManager : MonoBehaviour
{
    public List<PhysicsObject> physicsObjects = new List<PhysicsObject>();
    //Mouse Position Vector 3
    private Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get mouse position, which will be in terms of screen
        mousePosition = Mouse.current.position.ReadValue();
        //Then convert to world coordinates
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //For each object that was added to the list, check the distance between the object and mouse
        foreach (PhysicsObject physicsObject in physicsObjects){
            Vector3 mouseToObjectPosition = new Vector3(mousePosition.x - physicsObject.transform.position.x, mousePosition.y - physicsObject.transform.position.y, 0);
            //Then apply said found force
            physicsObject.ApplyForce(mouseToObjectPosition);
        }

    }
}
