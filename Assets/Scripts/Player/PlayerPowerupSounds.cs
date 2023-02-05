using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerupSounds : MonoBehaviour
{
    public AudioClip powerUpSound;
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ClockPowerup") || other.CompareTag("RootPowerup") || other.CompareTag("MagnetPowerup"))
        {
            _audioSource.clip = powerUpSound;
            _audioSource.Play();
        }
    }
}
