using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public GameManager GameManager;
    public bool hasDroplet;
    public int score;

    void Start()
    {
        hasDroplet = false;
        score = 0;
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
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
            Debug.Log(score);
        }

    }
}
