using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefab;
    public float startDelay = 2f;
    public float repeatRate = 2f;
    private Vector3 spawnPos = new Vector3(25,0,0);
    private PlayerController playerControllerScript;
    

    // Start is called before the first frame update
    void Start()
    {   // Makes SpawnObstacle repeat with delay and repeat rate
        InvokeRepeating("SpawnObstacle",startDelay,repeatRate);
        // Goes into "Player" and finds the PlayerController Script in order to control spawns based on if game is over
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();  
    }

    void SpawnObstacle()
    {   // If game has not ended, continue to spawn obstacles
        if(playerControllerScript.isGameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation); 
        }
    }
}
