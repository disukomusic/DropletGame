using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Obstacle
{
    private float _previousPlayerSpeed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player entered mushroom zone");
            _previousPlayerSpeed = other.GetComponent<PlayerMove>().movementSpeed;
            other.GetComponent<PlayerMove>().movementSpeed = 300;
        } 
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player exited mushroom zone");
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
        Destroy(gameObject);
    }
}
