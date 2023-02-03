using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject startPanel;
    public GameObject endPanel;
    public GameObject hudPanel;

    private void Awake()    
    {
        startPanel.SetActive(true);
        endPanel.SetActive(false);
        hudPanel.SetActive(false);
    }

    void Update()
    {
        if (gameManager.GetGameState() == GameState.GameOver)
        {
            SetGameOverPanels();
        }
        else if (gameManager.GetGameState() == GameState.Gameplay)
        {
            SetGamePlayPanels();
        }
    }

    private void SetGamePlayPanels()
    {
        startPanel.SetActive(false);
        endPanel.SetActive(false);
        hudPanel.SetActive(true);
    }
    
    private void SetGameOverPanels()
    {
        startPanel.SetActive(false);
        endPanel.SetActive(true);
        hudPanel.SetActive(false);
    }
}