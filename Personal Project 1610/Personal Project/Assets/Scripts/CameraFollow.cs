using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 10f; //this variable changes how fast or how slow the camera chases after the player
    public Vector3 offset;

    private Vector3 cameraSpawnPos = new Vector3(-26,17,16);
    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.position = cameraSpawnPos;
    }

    void LateUpdate() //LateUpdate is used so the camera follows after the player movement, reducing any jitter effects
    {
        if(gameManagerScript.isGameOn)
        {
            Vector3 desiredPosition = target.position + offset; //desired postition is the position where we want the camera to be
            Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed * Time.deltaTime); //smoothed position is used to create a slow or fast effect towards the player
            transform.position = smoothedPosition;
        }
    }
}
