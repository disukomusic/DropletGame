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
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        float moveVertical = Input.GetAxisRaw ("Vertical");
        Vector3 movement = new Vector3(-moveHorizontal, 0.0f, -moveVertical);
        if (movement != Vector3.zero)
        {
            _transform.rotation = Quaternion.LookRotation(movement);
        }

    }
}
