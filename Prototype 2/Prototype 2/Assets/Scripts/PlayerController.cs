using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float hInput;

    private float xRange = 23.5f;

    public GameObject projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * hInput * Time.deltaTime * speed);

        if(transform.position.x < -xRange) //Restrains the player on both edges of the screen
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

         if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Launch the projectile prefab when space is pushed down
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation); 
        }
    }
}
