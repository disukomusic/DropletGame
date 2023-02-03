using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;


public class PlayerCollect : MonoBehaviour
{
    public GameManager GameManager;
    public bool hasDroplet;
    public int score;
    public TMP_Text scoreText;

    void Start()
    {
        hasDroplet = false;
        score = 0;
        scoreText.text = score.ToString();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Droplet") )
        {
            hasDroplet = true;
            WaterDestroy droplet = other.GetComponent<WaterDestroy>();
            droplet.Collect();
        }
        else
        if (other.CompareTag("Deposit") && hasDroplet)
        {
            GameManager.WaterSpawner.SpawnWater();
            hasDroplet = false;
            score += 1;
            scoreText.text = score.ToString();
            Debug.Log(score);
        }
    }
}
