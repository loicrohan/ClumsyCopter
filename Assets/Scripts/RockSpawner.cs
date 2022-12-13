using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject Rocks;
    
    public float frequency = 1;
   
    private void Start()
    {
        InvokeRepeating("SpawnRocks", 1, frequency);
    }
    
    void SpawnRocks()
    {
        Vector3 randomPos = new Vector3(transform.position.x, Random.Range(-0.46f, 2.78f), transform.position.z);
        
        Instantiate(Rocks, randomPos, transform.rotation);
    }
}