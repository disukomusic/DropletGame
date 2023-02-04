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
        if (movement == Vector3.zero)
        {
            return;
        }
        Quaternion targetRotation = Quaternion.LookRotation(movement);
        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.deltaTime);
        _transform.rotation = targetRotation;
    }
}
