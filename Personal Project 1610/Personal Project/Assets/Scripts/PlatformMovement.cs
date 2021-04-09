using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    public float speed;
    private float leftBound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.CompareTag("PLAT_MOVE_LEFT"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        
        if(gameObject.CompareTag("PLAT_MOVE_RIGHT"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }




        //if(transform.position.x > leftBound)
    }
}
