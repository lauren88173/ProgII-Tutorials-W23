using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
    
{
    [SerializeField] Transform trans;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 100f;
   
    void Start()
    {
        StartCoroutine(shoot());
    }

    IEnumerator shoot()
    {
        while (true)
        {
            Rigidbody obj = Instantiate(bullet, trans.position, trans.rotation).GetComponent<Rigidbody>();
            obj.velocity = trans.forward * bulletSpeed;
            //returning value of time so that the bullets fire every x seconds. Makes it wait 5 seconds before firing instead of checking if its been 5 seconds
            yield return new WaitForSeconds(5f);
        }
    }
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
