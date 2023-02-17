using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //Movement Variables
    [SerializeField] float movementSpeed = 8f;
    [SerializeField] float rotationSpeed = 30f;
    public int jumpForce;
    bool jump = false;

    //Movement Checks
   // [SerializeField] float distanceFromGround = 2f;
    [SerializeField] LayerMask ground;
    bool playerIsGrounded;

    //Physics Variables
    float verticalInput;
    float horizInput;
    Rigidbody rB;
    CapsuleCollider capsuleCollider;
   
        


    
    
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
        PlayerMovement();
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        
    }

    private void FixedUpdate()
    {
        
        if(jump == true && playerIsGrounded == true)
        {
            PlayerJump(); 
        }
        jump = false;
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
        
        rB.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        playerIsGrounded = false;
        

    }
    //stay instead of enter so its always checking if its on the ground
  private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            for (int i = 0; i < collision.contacts.Length; i++)
            {
                if (collision.GetContact(i).normal.y > 0.5)
                {
                    playerIsGrounded = true;
                  
                }
            }
        }
    }
    //when I leave touching any object, it sets grounded to false
    private void OnCollisionExit(Collision collision)
    {
        playerIsGrounded = false;
    }


}
