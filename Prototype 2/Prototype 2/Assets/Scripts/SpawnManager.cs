using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float SpawnRangeX = 23.5f;
    private float SpawnPosZ = 20; 
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimals",startDelay,spawnInterval);
    }

    void SpawnRandomAnimals(){
        // Randomly Generate animal spawn position and animal type
            Vector3 spawnPos = new Vector3(Random.Range(-SpawnRangeX, SpawnRangeX),0,SpawnPosZ);
            int animalIndex = Random.Range(0,animalPrefabs.Length);
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
