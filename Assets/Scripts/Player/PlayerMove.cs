using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float movementSpeed;
    
    void Start()
    {
        
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x: horizontal, y:0, z: -vertical);
        _rigidbody.AddForce(direction * movementSpeed);
    }
}