using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Magnet : PowerUp
{
    private Transform _player;
    private PlayerCollect _playerCollect;
    //private SphereCollider _collider;
    private bool _isTimerDone;
    private Transform target;
    
    private void Start()
    {
        //originally was going to have droplet move towards the magnet,
        //could not make it work :(
        //_collider = GetComponent<SphereCollider>();
        //_collider.radius = 8.44f;
        
        _isTimerDone = false;
        
        transform.rotation = Quaternion.Euler(0f, 0f, -90f);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject targetObject = GameObject.FindWithTag("Droplet");
            if (targetObject)
            {
                target = targetObject.transform;
            }
            Clear();
            PowerUpSpawner.count -= 1;
            _isTimerDone = false;
            _player = other.GetComponent<Transform>();
            _playerCollect = _player.GetComponent<PlayerCollect>();
            StartCoroutine(MagnetTimer());
        }
    }

    private void Update()
    {
        if (_player)
        {
            if (!_isTimerDone && !_playerCollect.hasDroplet) 
            {
                transform.position = _player.position + new Vector3(0f, 10f, 0f);
                //_collider.radius = 50f;
                
                if (target)
                {
                    //chatGPT figured out this part because it is 2am and I do not have the brain capacity to think
                    //about quaternions
                    
                    // Calculate rotation towards target
                    Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);

                    // Add additional 90 degree counterclockwise rotation around the x-axis
                    rotation *= Quaternion.AngleAxis(-90, new Vector3(1, 0, 0));

                    // Rotate towards target
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 15f * Time.deltaTime);
                }
            }
            else
            {
                //_collider.radius = 8.44f;
            }
            
            if (_playerCollect.hasDroplet)
            {
                _isTimerDone = true;
                Destroy(gameObject);
            }
        }
    }

    IEnumerator MagnetTimer()
    {
        yield return new WaitForSeconds(10);
        _isTimerDone = true;
        Destroy(gameObject);
    }

}