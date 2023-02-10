using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    [SerializeField] int _bulletDamage;
    public Rigidbody rb; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5f);
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player_Behaviour>().DamagePlayer(_bulletDamage);
        }
        Destroy(gameObject);
    }

}
//Ctrl RR to change all instances of something.