using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositParticles : MonoBehaviour
{
    public GameObject player;
    
    private PlayerCollect _playerCollect;
    private ParticleSystem _particleSystem;

    void Start()
    {
        _particleSystem = GetComponent <ParticleSystem>();
        _playerCollect = player.GetComponent<PlayerCollect>();
    }

    void Update()
    {
        if (_playerCollect.hasDroplet)
        {
           _particleSystem.enableEmission = true;
        }
        else
        {
            _particleSystem.enableEmission = false;
        }
        
    }
}
