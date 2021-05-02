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
    private float leftBound = 33;
    private float rightBound = -120;
    public Vector3 playerSpawnPos = new Vector3(32,14,-5);

    public bool isTakeDamage = false;
    public bool isOnGround = true;

    private int extraJumps;
    public int extraJumpsValue;

    private bool hasWings = false;
    public GameObject wingsIndicator;

    public float healthValue = 10;
    public TextMeshProUGUI healthText;
    private GameManager gameManagerScript;

    public Vector3 checkpointSpawnPos;

    public AudioClip jumpSound;
    private AudioSource playerAudio;

    public ParticleSystem healthParticles;
    public ParticleSystem wingsParticles;
    

    // Start is called before the first frame update
    void Start()
    {   //Grabs the Rigidbody component from the player
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
        extraJumps = extraJumpsValue;

        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        //Grabs the axis for control
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
 
      if(gameManagerScript.isGameOn)
      {
        transform.Translate(Vector3.forward * Time.deltaTime * speed *hInput);
      }

      if(isOnGround == true) //Resets the extraJumpsValue when the jump ends and player lands on ground
      {
          extraJumps = extraJumpsValue;
      }

        //if player pushes space bar,isOnGround, and has extra jumps, allows the player to jump more than once
      if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
      {
          playerRb.velocity = Vector3.up * jumpForce;
          isOnGround = false;
          extraJumps--;
          playerAudio.PlayOneShot(jumpSound, 1.0f);
      }
      else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isOnGround == true) //if function above isn't active, then it means player can only jump once here
      {
         playerRb.velocity = Vector3.up * jumpForce;
         playerAudio.PlayOneShot(jumpSound, 1.0f);
         isOnGround = false;
         Debug.Log("Backup jump");
      }

      //if player goes too far to the left, stop movement
      if(transform.position.x > leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }

        //if player goes too far to the right, stop movement
      if(transform.position.x < rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }

        //If player gets the wings, allows double jump
      if(hasWings == true && isOnGround == true)
      {
          extraJumpsValue = 2;
      }

      if(gameManagerScript.isGameOn) //Function that displays players health
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
        //if player walks over checkpoint platform, sets the respawn position to the checkpoint position
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            playerSpawnPos = checkpointSpawnPos;
            Debug.Log("Checkpoint Reached");
            isTakeDamage = false;
        }
        //if player walks over the finish line, player wins the game
        if(other.gameObject.CompareTag("FinishLine"))
        {
            gameManagerScript.WinGame();
        }
    }

      private void OnTriggerEnter(Collider other)
    {   // Gives the player wings and allows double jump after colliding with wings
        if(other.gameObject.CompareTag("Wings"))
        {
            wingsParticles.Play();
            wingsIndicator.gameObject.SetActive(true);
            hasWings = true;
            Destroy(other.gameObject);
            Debug.Log("Wings Collected");
        }
        // Allows the player the ability to pick up health potions for extra health
        if(other.gameObject.CompareTag("Potion"))
        {
            healthParticles.Play();
            healthValue++;
            Destroy(other.gameObject);
            Debug.Log("Health Potion Collected");
        }
    }

    private void ShowHealth() // Function that ends the game if the players health hits 0
    {
        if(healthValue < 1)
        {
            gameManagerScript.GameOver();
        }
        healthText.text = "Health :" + healthValue;
    }
}
