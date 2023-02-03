using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private GameState _gameState;

    public Player Player;
    public WaterSpawn WaterSpawner;
    public UIManager UIManager;
    public Timer Timer;

    private int score;
    public TextMeshProUGUI scoreText;

    void Start()    
    {
        _gameState = GameState.StartScreen;
    }

    public void GameStart()
    {
        _gameState = GameState.Gameplay;
        Timer.StartTimer();
        Debug.Log("game start");
        WaterSpawner.SpawnWater();
        Player.ResetPlayerPosition();
        Player.ResetScore();
    }

    public void GameEnd()
    {
        _gameState = GameState.GameOver;
        Timer.StopTimer();
        Debug.Log("game end");
        Debug.Log("Your score was " + Player.score);
        _gameState = GameState.GameOver;
    }
    
    public GameState GetGameState()
    {
        return _gameState;
    }
}