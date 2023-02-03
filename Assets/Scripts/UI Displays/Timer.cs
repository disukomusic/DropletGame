using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class Timer : MonoBehaviour
{
    public GameManager GameManager;
    public float timerTime;
    private float _timeRemaining = 10;
    public bool timerIsRunning = false;
    public TMP_Text timeText;
    private void Start()
    {
        timerIsRunning = false;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
                DisplayTime(_timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                _timeRemaining = 0;
                timerIsRunning = false;
                GameManager.GameEnd();
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        _timeRemaining = timerTime;
        timerIsRunning = true;
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }
}