using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behaviour : MonoBehaviour
{
    Rigidbody rb;
    float inputX, inputY;
   
    public float bulletVelocity;
    bool shoot = false;

    public GameObject bullet;
    public Transform bulletPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      

        if (Input.GetMouseButtonDown(0))
        {
            shoot = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(inputX * bulletVelocity, rb.velocity.y, inputY * bulletVelocity);
      
        if (shoot)
        {
            Shoot();
            shoot = false;
        }
    }
    void Shoot()
    {
        GameObject bulletSpawn = Instantiate(bullet, bulletPos.position, bullet.transform.rotation);

        bulletSpawn.GetComponent<Rigidbody>().velocity = bulletPos.forward * bulletVelocity;
    }
}
