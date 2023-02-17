using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    //What do we want to follow?
    public Transform target;

    //somewhere between 0 and 1
    public float smoothCamSpeed = .125f;

    //adding offset so the camera isnt inside the player
    public Vector3 camOffset;

    
    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + camOffset;
       //Lrp = smoothly going from one point to another
        Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothCamSpeed /* * Time.deltaTime*/);
        transform.position = smoothedPosition;


        //making the camera look at the player
        transform.LookAt(target);
    }
}
