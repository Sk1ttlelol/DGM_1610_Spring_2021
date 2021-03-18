using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public float speed;
    public float hInput;
    public float leftBound = 11;
    //variable to grab player controller script
    private PlayerController playerControllerScript;

    public Vector3 cameraSpawnPos = new Vector3(10,17,16);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = cameraSpawnPos;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {  
        hInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed *hInput);

        //if position of camera goes too far left, stop movement
        if(transform.position.x > leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }
        //if isTakeDamage from playerControllerScript becomes true, move camera to respawn postiion to continue following player
        if(playerControllerScript.isTakeDamage == true)
        {
            transform.position = cameraSpawnPos;
        }
    }
}
