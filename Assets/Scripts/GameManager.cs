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
    public PowerUpSpawner PowerUpSpawner;
    public Timer Timer;
    public TMP_Text endScoreText;

    private int _score;
    private GameState _gameState;
    private Player _player;
    
    void Start()    
    {
        _gameState = GameState.StartScreen;
        _player = Player.GetComponent<Player>();
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
        StartCoroutine(PowerUpTimer());
    }

    IEnumerator PowerUpTimer()
    {
        Debug.Log("Started Powerup Timer");
        while (Timer._timeRemaining > 0)
        {
            yield return new WaitForSeconds(Random.Range(15, 30));
                PowerUpSpawner.SpawnPowerup();
        }
    }
    
    public void GameEnd()
    {
        endScoreText.text = ("Score:" + Player.GetComponent<Player>().score.ToString());
        _gameState = GameState.GameOver;
        Timer.StopTimer();
        StopCoroutine(PowerUpTimer());
        Debug.Log("game end"); 
    }
    
    public GameState GetGameState()
    {
        return _gameState;
    }
}