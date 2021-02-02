using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speedValue = 20.0f;     


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-15,2,-8);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speedValue);

    }
}
