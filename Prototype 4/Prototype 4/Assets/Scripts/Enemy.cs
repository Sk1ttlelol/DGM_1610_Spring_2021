using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized; //Enemy follows player based on position
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

        if(transform.position.y < -10) // if the enemy falls off the platform, destroy enemy
        {
            Destroy(gameObject);
        }
    }
}
