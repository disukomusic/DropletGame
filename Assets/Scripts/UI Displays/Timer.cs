using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class Timer : MonoBehaviour
{
    public GameManager GameManager;
    public static Timer instance; 
    public float timerTime;
    public bool timerIsRunning = false;
    public TMP_Text timeText;
    
    [HideInInspector] public float _timeRemaining = 10;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    private void Start()
    {
        WhiteText();
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
                if (_timeRemaining < 15)
                {
                    RedText();
                }
                else
                {
                    WhiteText();
                }
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

    void RedText()
    {
        timeText.color = Color.red;
    }

    void WhiteText()
    {
        timeText.color = Color.white;
    }
    public void StartTimer()
    {
        WhiteText();
        _timeRemaining = timerTime;
        timerIsRunning = true;
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }
}