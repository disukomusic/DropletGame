using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameState gameState;

    public Player Player;
    public WaterSpawn WaterSpawner;
    public UIManager UIManager;
    public Timer Timer;


    void Start()    
    {
        gameState = GameState.StartScreen;
    }

    public void GameStart()
    {
        gameState = GameState.Gameplay;
        Timer.StartTimer();
        Debug.Log("game start");
        WaterSpawner.SpawnWater();
        Player.ResetPlayerPosition();
    }
    
    public void TimerEnd()
    {
        
    }
    
    public GameState GetGameState()
    {
        return gameState;
    }
}