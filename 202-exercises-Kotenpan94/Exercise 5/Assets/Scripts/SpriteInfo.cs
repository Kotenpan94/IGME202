using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteStored;
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;
    public Vector2 center;
    public Vector3 size;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        maxX = spriteStored.bounds.max.x;
        maxY = spriteStored.bounds.max.y;
        minX = spriteStored.bounds.min.x;
        minY = spriteStored.bounds.min.y;
        size = spriteStored.bounds.size;
        center = spriteStored.bounds.center;
    }
}
