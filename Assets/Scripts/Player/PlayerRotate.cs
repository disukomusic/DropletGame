using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _rotate;

    
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(-horizontalInput, 0, -verticalInput).normalized;
        
        //if the movement is (0,0,0) [no input from player], exit the method for this frame
        if (movement == Vector3.zero)
        {
            return;
        }   
        
        //Rotate towards the target rotation
        Quaternion targetRotation = Quaternion.LookRotation(movement);
        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.deltaTime);
        _transform.rotation = targetRotation;
    }
}
