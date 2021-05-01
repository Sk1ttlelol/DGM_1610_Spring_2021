using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemyMovement : MonoBehaviour
{

    public float topBound = 24;
    public float bottomBound = 15;
    public float speed;
    public bool topBoundReached = true;
    public bool bottomBoundReached;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > topBound) // These two functions check if the enemy has hit a certain Y threshold and creates the effect of the enemy moving up and down on repeat
        {
            topBoundReached = true;
            bottomBoundReached = false;
            Debug.Log("top bound hit");
        }

        if(transform.position.y < bottomBound)// Like a toggle switch
        {
            topBoundReached = false;
            bottomBoundReached = true;
        }

        //Checks if the enemy has hit the top or bottom limit, then reverses direction of movement
        if(transform.position.y < topBound && topBoundReached == false)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        if(transform.position.y > bottomBound && bottomBoundReached == false)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }
}
