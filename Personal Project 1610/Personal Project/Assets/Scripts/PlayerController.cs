using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    private int extraJumps;
    public int extraJumpsValue;

    private bool hasWings = false;

    public float healthValue = 10;
    public TextMeshProUGUI healthText;
    private GameManager gameManagerScript;
    

    // Start is called before the first frame update
    void Start()
    {   //Grabs the Rigidbody component from the player
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
        extraJumps = extraJumpsValue;

        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {   
        
        //Grabs the axis for control
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed *hInput);

      if(isOnGround == true)
      {
          extraJumps = extraJumpsValue;
      }

        //if player pushes space bar,isOnGround, and has extra jumpsplayer go boing boing
      if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
      {
          playerRb.velocity = Vector3.up * jumpForce;
          isOnGround = false;
          extraJumps--;
      }
      else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isOnGround == true)
      {
         playerRb.velocity = Vector3.up * jumpForce;
         isOnGround = false;
         Debug.Log("Backup jump");
      }

      //if player goes too far to the left, stop movement
      if(transform.position.x > leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }
        //If player gets the wings, allows double jump
      if(hasWings == true && isOnGround == true)
      {
          extraJumpsValue = 2;
      }

      if(gameManagerScript.isGameOn)
      {
          healthText.gameObject.SetActive(true);
          ShowHealth();
      }
    }

    private void OnCollisionEnter(Collision other)
    {   //Checks if the player is on the ground
        if(other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
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
            healthValue--;
        }
        //if isTakeDamage becomes true, move player to respawn position
        if(isTakeDamage == true)
        {
            transform.position = playerSpawnPos;

        }
    }

      private void OnTriggerEnter(Collider other)
    {   // Gives the player wings and allows double jump after colliding with wings
        if(other.gameObject.CompareTag("Wings"))
        {
            hasWings = true;
            Destroy(other.gameObject);
            Debug.Log("Wings Collected");
        }
    }


    private void ShowHealth()
    {
        if(healthValue < 1)
        {
            gameManagerScript.GameOver();
        }
        healthText.text = "Health :" + healthValue;
    }
    
}
