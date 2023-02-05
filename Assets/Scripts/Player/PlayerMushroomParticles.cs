using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMushroomParticles : MonoBehaviour
{
    public ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem.enableEmission = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mushroom"))
        {
            particleSystem.enableEmission = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Mushroom"))
        {
            particleSystem.enableEmission = false;
        }
    }
}
