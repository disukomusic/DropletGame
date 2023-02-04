using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpeedUp : PowerUp
{
    private PlayerMove _playerMove;
    private GameObject _player;
    public bool emitParticles;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Clear();
            PowerUpSpawner.count -= 1;
            _playerMove = other.GetComponent<PlayerMove>();
            _playerMove.movementSpeed += 200;
            StartCoroutine(SpeedUpTimer());
            //im gonna warn you this next line is really REALLY stupid
            gameObject.transform.position += new Vector3(1000, 100, 100);
        }
    }

    IEnumerator SpeedUpTimer()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
        _playerMove.movementSpeed = 700;
    }
    
}
