using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    

    public GameObject Player;
    public WaterSpawn WaterSpawner;
    public UIManager UIManager;
    public Timer Timer;
    public TMP_Text endScoreText;
    
    private int _score;
    private GameState _gameState;
    private Player _player;
    


    void Start()    
    {
        _gameState = GameState.StartScreen;
        Player _player = Player.GetComponent<Player>();
    }

    public void GameStart()
    {
        _gameState = GameState.Gameplay;
        Timer.StartTimer();
        WaterSpawner.SpawnWater();
        _player.ResetPlayerPosition();
        _player.ResetScore();
        _player.GetComponent<PlayerCollect>().scoreText.text = 0.ToString();
        Debug.Log("game start");
    }

    public void GameEnd()
    {
        endScoreText.text = ("Your score was:" + Player.GetComponent<Player>().score.ToString());
        _gameState = GameState.GameOver;
        Timer.StopTimer();
        Debug.Log("game end"); 
    }
    
    public GameState GetGameState()
    {
        return _gameState;
    }
}