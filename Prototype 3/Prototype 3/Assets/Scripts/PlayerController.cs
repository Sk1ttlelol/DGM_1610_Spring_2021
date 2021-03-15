using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityMod;
    public bool isOnGround = true;
    public bool isGameOver = false;
    private Animator playerAnim;
    public ParticleSystem dirtParticles;
    public ParticleSystem explosionParticles;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        // Variable is found from getting component from specific tool
        playerRb = GetComponent<Rigidbody>(); 
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        // if space bar is pushed, player is on the ground, and the game is not over, 
      if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)  
      { //Makes player jump go boing boing
          playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
          isOnGround = false;
        // Jump animation starts, dirt particles stop, jump sound is played
          playerAnim.SetTrigger("Jump_trig");
          dirtParticles.Stop();
          playerAudio.PlayOneShot(jumpSound, 1.0f);
      }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If player is touching ground, play dirt particles
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Debug.Log("Grounded");
            dirtParticles.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {   //if player collides with object, game ends, death animation occurs, dirt particles stop, explosion particles are created and crash sound starts
            isGameOver = true;
            Debug.Log("Game Over oof");
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticles.Play();
            dirtParticles.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }


    }
}
