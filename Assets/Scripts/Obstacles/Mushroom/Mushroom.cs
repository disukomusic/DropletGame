using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Obstacle
{
    private float _previousPlayerSpeed;
    private PlayerMove _player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player entered mushroom zone");
            
            _player = other.GetComponent<PlayerMove>();
            _previousPlayerSpeed = _player.movementSpeed;
            _player.movementSpeed = 200;
        } 
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player exited mushroom zone");
            Debug.Log(_previousPlayerSpeed);
            other.GetComponent<PlayerMove>().movementSpeed = 700;
        } 
    }

    private void Awake()
    {
        StartCoroutine(MushroomTimer());
    }       

    IEnumerator MushroomTimer()
    {
        yield return new WaitForSeconds(10);
        if (_player) 
        {
            _player.movementSpeed = 700f;
        }
        Destroy(gameObject);
    }
}
