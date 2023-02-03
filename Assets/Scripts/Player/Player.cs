using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _transform;
    private PlayerCollect _playerCollect;
    
    public float score;
    public GameManager gameManager;
    void Start()
    {
        _transform = GetComponent<Transform>();
        _playerCollect = GetComponent<PlayerCollect>();
    }
    public void ResetPlayerPosition()
    {
        _transform.position = new Vector3(0, 19.05f, -65.05f);
    }

    public void ResetScore()
    {
        _playerCollect.score = 0;
    }

    
    void Update()
    {
        score = GetComponent<PlayerCollect>().score;
    }
}
