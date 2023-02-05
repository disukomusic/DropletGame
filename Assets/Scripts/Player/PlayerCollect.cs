using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;


public class PlayerCollect : MonoBehaviour
{
    public GameManager GameManager;
    public PowerUpSpawner PowerUpSpawner;
    public bool hasDroplet;
    public int score;
    public TMP_Text scoreText;
    public GameObject infoText;
    public AudioSource audioSource;
    public AudioClip dropletPickupSound;
    public AudioClip dropletDepositSound;
    
    private InfoText _infoText;
    

    void Start()
    {
        hasDroplet = false;
        
        score = 0;
        scoreText.text = score.ToString();
        _infoText = infoText.GetComponent<InfoText>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Droplet") )
        {
            hasDroplet = true;
            
            audioSource.clip = dropletPickupSound;
            audioSource.Play();
            
            WaterDestroy droplet = other.GetComponent<WaterDestroy>();
            droplet.Collect();
            _infoText.DepositDroplets();
        }
        else
        if (other.CompareTag("Deposit") && hasDroplet)
        {
            hasDroplet = false;
            
            audioSource.clip = dropletDepositSound;
            audioSource.Play();
            
            GameManager.WaterSpawner.SpawnWater();
            
            score += 1;
            scoreText.text = score.ToString();
            _infoText.CollectDroplets();
        }
    }
}
