using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Behaviour : MonoBehaviour
{

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("You have collected a coin!");
            FindObjectOfType<AudioManager>().Play("Coin_Pickedup");
        }
    }

}
