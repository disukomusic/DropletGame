using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Player _player;
    
    public float movementSpeed; 
    public float jumpForce;
    public bool grounded;
    
    void Start()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(_player.gameManager.GetGameState() == GameState.Gameplay)
        {
            _rigidbody.velocity = new Vector3(- Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, _rigidbody.velocity.y, -Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
        }
    }

    void Update()
    {
        if(_player.gameManager.GetGameState() == GameState.Gameplay)
        {
            if(Input.GetButtonDown("Jump") && grounded)
            {
                _rigidbody.velocity = new Vector3(0,jumpForce,0);
            }
            else if(Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                _rigidbody.velocity = new Vector3(0,jumpForce,0);
            }
        }

    }
}