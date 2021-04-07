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
    public Vector3 playerSpawnPos = new Vector3(32,14,-5);

    public bool isTakeDamage = false;
    public bool isOnGround = true;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private int extraJumps;
    public int extraJumpsValue;

    private bool hasWings = false;
    

    // Start is called before the first frame update
    void Start()
    {   //Grabs the Rigidbody component from the player
        playerRb = GetComponent<Rigidbody>();
        extraJumps = extraJumpsValue;

        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {   
       //playerRb.velocity = new Vector3(vInput * speed, playerRb.velocity.y, playerRb.velocity.z);
        
        //Grabs the axis for control
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.left * Time.deltaTime * speed *hInput);

        //if player pushes space bar, and isOnGround, player go boing boing
      if(Input.GetKeyDown(KeyCode.Space) && isOnGround == true && extraJumps > 0)
      {
          isJumping = true;
          jumpTimeCounter = jumpTime;
          playerRb.velocity = Vector3.up * jumpForce;
          //playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
          isOnGround = false;
          extraJumps--;
      } 
      else if(Input.GetKeyDown(KeyCode.Space) && isOnGround == true && extraJumps == 0)
      {
         playerRb.velocity = Vector3.up * jumpForce;
         isJumping = true;
         jumpTimeCounter = jumpTime;
      }

      if(Input.GetKey(KeyCode.Space) && isJumping == true)
      {
        if(jumpTimeCounter > 0)
        {
           //playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
           playerRb.velocity = Vector3.up * jumpForce;
           jumpTimeCounter -=Time.deltaTime; 
        }
        else{
            isJumping = false;
        } 
      }

      if(Input.GetKeyUp(KeyCode.Space))
      {
          isJumping = false;
      }

      //if player goes too far to the left, stop movement
      if(transform.position.x > leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision other)
    {   
        if(other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            //extraJumps = 2;
            Debug.Log("Grounded");
        }
        
        //if player touches respawn platform, isTakeDamage becomes false
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
