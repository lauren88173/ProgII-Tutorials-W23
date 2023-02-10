using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Vision : Enemy_Behaviour
{
    public GameObject target;

    void Start()
    {

    }

    void Update()
    {
        Vector3 newPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(newPos);
    }
}
