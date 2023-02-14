using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public int numCreatures = 4;

    public GameObject creaturePrefab;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {

        float xPos = -1f;
        float yPos = 1f;
        float zPos = 0f;

        for(int i = 0; i < numCreatures; i++)
        {
            Instantiate(creaturePrefab, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            xPos += 2;
            zPos += 3;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
