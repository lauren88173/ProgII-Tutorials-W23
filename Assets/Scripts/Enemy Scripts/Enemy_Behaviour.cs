using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
    
{
    [SerializeField] Transform trans;
    [SerializeField] GameObject bullet;
   
    //For following the player with their vision
  /*  public GameObject target;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 newPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(newPos);
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered enemy range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has left enemy range");
        }
    }
}
