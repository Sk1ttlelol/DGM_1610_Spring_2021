using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    public float speed;
    public float leftBound = 60;
    public float rightBound = 1;
    
    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > leftBound)
        {
            Destroy(gameObject);
        }

        if(transform.position.x < rightBound)
        {
            Destroy(gameObject);
        }
        if(gameObject.CompareTag("PLAT_MOVE_LEFT"))
        {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        
        if(gameObject.CompareTag("PLAT_MOVE_RIGHT"))
        {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
