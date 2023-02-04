using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The new ExtraTime class inherents from the PowerUp category and has access to everything from it
public class ExtraTime : PowerUp
{
    public Timer _timer;
    public float extraTime = 20;

    void Awake()
    {   
        _timer = Timer.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Clear();
            PowerUpSpawner.count -= 1;
            _timer._timeRemaining += extraTime;
            Destroy(gameObject);
        } 
    }
}
