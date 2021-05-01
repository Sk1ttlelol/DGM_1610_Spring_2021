using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 35.0f;
    private float lowerBound = -15.0f; 

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBound) // If the position of the object is greater than 35 on Z, destroy the game object
        {
            Destroy(gameObject);
        }
        else if(transform.position.z < lowerBound) //If the position of the object is greater than -15 on Z, destroy the game object
        {
            Debug.Log("GAME OVER!");
            Destroy(gameObject);
        }
    }
}
