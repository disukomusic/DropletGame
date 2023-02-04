using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : PowerUp
{
    public Player _player;
    public Player movementSpeed;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Clear();
            PowerUpSpawner.count -= 1;
            movementSpeed + 10;
            Destroy(gameObject);
        }
    }
}
