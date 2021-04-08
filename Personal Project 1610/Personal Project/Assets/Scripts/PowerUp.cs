using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
      private void onTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //hasWings = true;
            Destroy(other.gameObject);
            Debug.Log("Wings Collected");
        }
    }
}
