using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    public float turnAmount = 360f;
    public bool useDeltaTime = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Starts out as false default so if statement is just looking to see the bool
        if (!useDeltaTime)
        {
            transform.Rotate(new Vector3(0,0, turnAmount));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -turnAmount * Time.deltaTime));

        }
    }
}
