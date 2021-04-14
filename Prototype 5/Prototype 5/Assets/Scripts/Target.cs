using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    private float minSpeed = 12, maxSpeed = 16, maxTorque = 10, xRange = 4, ySpawnPos = -6;

    private GameManager gameManagerScript;

    public int pointValue;

    public ParticleSystem splosionsParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque( RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = (RandomSpawnPos());
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(splosionsParticle, transform.position, splosionsParticle.transform.rotation);
        gameManagerScript.UpdateScore(pointValue);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
