using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;

    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn an Enemy
        SpawnEnemyWave(waveNumber);

        // Create Powerup for player to collect
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    void Update()
    {
        // Find how many enemies are in play
        enemyCount = FindObjectsOfType<Enemy>().Length;
        // If enemy count gets down to zero, spawn new enemies in greater number
        if(enemyCount == 0)
        {
            waveNumber ++;
            SpawnEnemyWave(waveNumber);

            // Create  additional Powerup pickups for the player to collect
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        // Spawn method that chooses between -9 and 9 on x,Z
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange); 
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation); 
        }
    }
}
