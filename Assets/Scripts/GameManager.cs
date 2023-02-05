using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{

    public GameObject Player;
    public WaterSpawn WaterSpawner;
    public PowerUpSpawner PowerUpSpawner;
    public ObstacleSpawner ObstacleSpawner;
    public UIManager UIManager;
    public InfoText infoText;
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
        _player.GetComponent<PlayerCollect>().hasDroplet = false;
        _player.GetComponent<PlayerMove>().movementSpeed = 700;
        Timer.StartTimer();
        WaterSpawner.SpawnWater();  
        _player.ResetPlayerPosition();
        _player.ResetScore();
        _player.GetComponent<PlayerCollect>().scoreText.text = 0.ToString();
        Debug.Log("game start");
        StartCoroutine(PowerUpTimer());
        StartCoroutine(ObstacleTimer());
    }

    IEnumerator PowerUpTimer()
    {
        Debug.Log("Started Powerup Timer");
        while (Timer._timeRemaining > 0)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            PowerUpSpawner.SpawnPowerup();
            infoText.NewPowerUp();
        }
    }

    IEnumerator ObstacleTimer()
    {
        Debug.Log("Started Obstacle Timer");
        while (Timer._timeRemaining > 0)
        {
            ObstacleSpawner.SpawnObstacle();
            yield return new WaitForSeconds(Random.Range(1, 5));
        }
    }
    
    public void GameEnd()
    {
        endScoreText.text = ("Score:" + Player.GetComponent<Player>().score);
        _gameState = GameState.GameOver;
        Timer.StopTimer();
        StopCoroutine(PowerUpTimer());
        StopCoroutine(ObstacleTimer());
        Debug.Log("game end"); 
    }
    
    public GameState GetGameState()
    {
        return _gameState;
    }
}