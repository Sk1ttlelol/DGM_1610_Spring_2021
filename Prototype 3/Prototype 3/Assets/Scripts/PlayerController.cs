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

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod; 
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space) && isOnGround)  
      { //Makes player jump go boing boing
          playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
          isOnGround = false;
      }
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Debug.Log("Grounded");
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            Debug.Log("Game Over oof");
        }


    }
}
