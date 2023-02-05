using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Obstacle
{
    private float _previousPlayerSpeed;
    private ParticleSystem _playerParticles;
    private PlayerMove _playerMove;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerParticles = other.GetComponent<ParticleSystem>();
            _playerMove = other.GetComponent<PlayerMove>();
            _previousPlayerSpeed = _playerMove.movementSpeed;
            _playerMove.movementSpeed = 200;
        } 
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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
        if (_playerMove) 
        {
            _playerParticles.enableEmission = false;
            _playerMove.movementSpeed = 700f;
        }

        ObstacleSpawner.count--;
        Destroy(gameObject);
    }
}
