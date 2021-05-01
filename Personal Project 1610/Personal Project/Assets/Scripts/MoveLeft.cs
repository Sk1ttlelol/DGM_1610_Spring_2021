using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    public float leftBound;
    public float rightBound;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > leftBound)
        {
            Destroy(gameObject);
        }

        if(transform.position.x < rightBound)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
