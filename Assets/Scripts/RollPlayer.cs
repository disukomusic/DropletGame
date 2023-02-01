using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollPlayer : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float movementSpeed;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(x: horizontal, y:0, z: vertical);
        _rigidbody.AddForce(direction * movementSpeed);
    }
}