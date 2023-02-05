using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The new ExtraTime class inherits from the PowerUp category and has access to everything from it
public class ExtraTime : PowerUp
{
    public Timer timer;
    public float extraTime = 30;

    void Awake()
    {   
        timer = Timer.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Clear();
            PowerUpSpawner.count -= 1;
            timer._timeRemaining += extraTime;
            Destroy(gameObject);
        } 
    }
}
