using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    //Creating a gameobject that can be accessed in the editor so that I can then put the prefab into to it.
    public TextMesh textMesh;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        //Created a list to easily store and keep track of the textmeshes
        List<TextMesh> clockNumberList = new List<TextMesh>();

        for (int i = -2; i < 10; i++)
        {   
            //Calculates floats that I want to treat as degrees
            float angle = 30f * i;
            //Because of that I need to convert to radians
            float angleDeg = -angle * Mathf.Deg2Rad;
            //Radius 
            float rad = 2f;
            //Calculated the x and y positions using cos and sin
            float xPos = Mathf.Cos(angleDeg) * rad;
            float yPos = Mathf.Sin(angleDeg) * rad;
            //Instantiated each number and then added to the clocknumber list
            clockNumberList.Add(Instantiate(textMesh, new Vector3(xPos, yPos, 0), Quaternion.identity));
            //Changed the text of each textmesh to the right number (added one to i, as 0 is not on the clock)
            clockNumberList[i+2].text = " " + (i+3);
            Debug.Log(xPos.ToString());
            Debug.Log(yPos.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
