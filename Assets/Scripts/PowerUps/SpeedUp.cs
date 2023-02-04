using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : PowerUp
{
    private PlayerMove _playerMove;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Clear();
            PowerUpSpawner.count -= 1;
            _playerMove = other.GetComponent<PlayerMove>();
            _playerMove.movementSpeed += 100;
            Destroy(gameObject);
            StartCoroutine(SpeedUpTimer());

        }
    }

    IEnumerator SpeedUpTimer()
    {
        yield return new WaitForSeconds(10);
        _playerMove.movementSpeed = 700;
    }
    
}
