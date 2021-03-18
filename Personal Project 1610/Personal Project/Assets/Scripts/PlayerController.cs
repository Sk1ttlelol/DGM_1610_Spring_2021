using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float hInput;
    public float vInput;
    public float jumpForce;
    private Rigidbody playerRb;
    public float gravityMod;
    public float leftBound = 33;
    public Vector3 playerSpawnPos = new Vector3(32,10,-5);

    public bool isTakeDamage = false;

    

    // Start is called before the first frame update
    void Start()
    {   //Grabs the Rigidbody component from the player
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {   //Grabs the axis for control
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.left * Time.deltaTime * speed *hInput);

        //if player pushes space bar, player go boing boing
      if(Input.GetKeyDown(KeyCode.Space))
      {
          playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      }
      //if player goes too far to the left, stop movement
      if(transform.position.x > leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision other)
    {   //if player touches respawn platform, isTakeDamage becomes false
        if(other.gameObject.CompareTag("Respawn"))
        {
            isTakeDamage = false;
        }
        //if player touches ground, spikes, or enemies, isTakeDamage becomes true
        if(other.gameObject.CompareTag("takeDamage"))
        {
            isTakeDamage = true; 
        }
        //if isTakeDamage becomes true, move player to respawn position
        if(isTakeDamage == true)
        {
            transform.position = playerSpawnPos;

        }

    }
}
