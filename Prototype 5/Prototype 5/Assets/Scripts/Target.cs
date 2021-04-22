using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12, maxSpeed = 16, maxTorque = 10, xRange = 4, ySpawnPos = -6;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem splosionsParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>(); //grabs rigidbody
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque( RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = (RandomSpawnPos());
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); //grabs game manager script
    }

    Vector3 RandomForce() //function that gives the prefabs their force
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque() //function that gives the prefabs their spin
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos() //function that allows the prefabs to spawn in a certain area at random
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    void OnMouseDown() //function that allows player to click on prefabs to gain score and create particles
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(splosionsParticle, transform.position, splosionsParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad")) //if an object that isnt tagged "Bad" is destroyed due to it hitting the sensor, tells gameManager to activate GameOver function
        {
            Debug.Log("Game Over");
            gameManager.GameOver();
        }
    }
}
