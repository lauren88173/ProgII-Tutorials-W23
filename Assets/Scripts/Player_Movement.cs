using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //Movement Variables
    [SerializeField] float movementSpeed = 8f;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] float rotationSpeed = 30f;

    //Movement Checks
    [SerializeField] float distanceFromGround = 2f;
    [SerializeField] LayerMask ground;

    //Physics Variables
    float verticalInput;
    float horizInput;
    Rigidbody rB;
    CapsuleCollider capsuleCollider;
   
        


    /*bool jumpCommand;
    bool playerIsGrounded;*/
    //Bullet Variables

    void Start()
    {
        rB = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        //Game Manager will be implemented as the game is developed further.
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        PlayerJump();
        //Shoot();
    }

    void PlayerMovement()
    {
        verticalInput = Input.GetAxis("Vertical") * movementSpeed;
        horizInput = Input.GetAxis("Horizontal") * rotationSpeed;
        transform.Rotate(Vector3.up * horizInput * Time.deltaTime);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime);
       
    }

    void PlayerJump()
    {
        /*cant quite get the 'check for ground' to work, so for now im commenting it out so that jumping works, though it has no restrictions */

        bool playerIsGrounded = Physics.Raycast(transform.position, Vector3.down, distanceFromGround, ground);
        if (Input.GetKeyDown(KeyCode.Space) && playerIsGrounded)
        {
            rB.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }

        else if (Input.GetKeyDown(KeyCode.Space) && !playerIsGrounded)
        {
            jumpSpeed = 0;
        }
       
        

    }

   /* private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            for (int i = 0; i < collision.contacts.Length; i++)
            {
                if (collision.contacts[i].normal.y > 1.5)
                {
                    playerIsGrounded = true;
                  
                }
            }
        }
    }
   */

}
