using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private List<SpriteRenderer> creatures = new List<SpriteRenderer>();
    public SpriteRenderer elephantPrefab;
    public SpriteRenderer turtlePrefab;
    public SpriteRenderer snailPrefab;
    public SpriteRenderer octopusPrefab;
    public SpriteRenderer kangarooPrefab;
    public int numCreatures = 10;
    private Vector3 minPosition;
    private Vector3 maxPosition;





    // Start is called before the first frame update
    void Start()
    {
        //Bottom left corner of camera
        minPosition = Camera.main.ScreenToWorldPoint(Vector3.zero);
        //Top right corner of camera
        maxPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        //Spawn first wave of creeatures
        Spawn();
    }

    // Update is called once per frame

    //Function for creating a new wave of creatures randomly in the world
    public void Spawn ()
    {
        //Clears screen before new creatures are spawned
        CleanUp();
        //Create a set number of creatures in the world
        for (int i = 0; i < numCreatures; i++)
        {
            //Place them at a random position


            //Add the creatures to the creatures list
            creatures.Add(SpawnCreature());

        }

    }
    private SpriteRenderer ChooseRandomCreature()
    {
        //Pick random creature from prefabs we have
        float randomValue = Random.Range(0f, 1f);
        //If statements for the probability 
        if (randomValue < .25f)
        {
            return elephantPrefab;
        }
        else if (randomValue >= .25f && randomValue < .45f)
        {
            return turtlePrefab;
        }
        else if (randomValue >= .45f && randomValue < .60f)
        {
            return snailPrefab;
        }
        else if (randomValue >= .60f && randomValue < .70f)
        {
            return octopusPrefab;
        }
        else if (randomValue >= .70f && randomValue < 1f)
        {
            return kangarooPrefab;
        }
        return kangarooPrefab;


    }
    private SpriteRenderer SpawnCreature()
    {
        //Instead of random range, use Gaussian
/*        Vector3 spawnPosition = new Vector3(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y), 0f);
*/        Vector3 spawnPosition = new Vector3(Gaussian(0f, 3f), Gaussian(0f, 1.85f), 0f);

        SpriteRenderer spawnedCreature = Instantiate(ChooseRandomCreature(), spawnPosition, Quaternion.identity);
        spawnedCreature.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);

        return spawnedCreature;

        //Spawn creature at random location in world and then return it 
    }
    private void CleanUp ()
    {
        foreach (SpriteRenderer creature in creatures)
        {
            Destroy(creature.gameObject);
        }
        creatures.Clear();

    }
    private float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue = 
            Mathf.Sqrt(-2.0f * Mathf.Log(val1)) * 
            Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;

    }
}
