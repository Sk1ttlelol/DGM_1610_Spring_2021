using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSpin : MonoBehaviour
{
    public float turnSpeed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * turnSpeed);
    }
}
