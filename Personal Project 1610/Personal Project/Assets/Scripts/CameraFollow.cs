using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 10f; 
    public Vector3 offset;

    public Vector3 cameraSpawnPos = new Vector3(10,17,16);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = cameraSpawnPos;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

    }
}
