using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public static int count = 0;
    public GameManager gameManager;
    public PowerUpSpawn[] waypoints;
    public GameObject[] powerUps;
    public Player Player;
    
    private int _lastPosRand = 0;
    private int _lastLastPosRand = 0;
    private int _lastPowerRand = 0;
    private GameObject _powerup;
    public void SpawnPowerup()
    {
        Debug.Log(count);

        //get a random index for the waypoints list, as well as a random index for the powerups list
        int posRand = GetRandomPosition();
        int powerRand = GetRandomPowerup();
        
        //generate indexes until a new one is returned
        while (posRand == _lastPosRand || posRand == _lastLastPosRand)
        {
            posRand = GetRandomPosition();
        }
        //store the index of the current waypoint as the last selected one
        _lastPosRand = posRand;
        _lastPowerRand = powerRand;
        
        //set the current waypoint to the random index and then set the position of it
        PowerUpSpawn currentWaypoint = waypoints[posRand];
        Vector3 waypointPos = currentWaypoint.waypoint.position;
        
        //instantiate a powerup at the position of the waypoint (and rotate so its upright, stupid blender)
        if (count < 3 && !currentWaypoint.hasPowerup)
        {
            currentWaypoint.hasPowerup = true;
            _powerup = Instantiate(powerUps[powerRand], waypointPos, Quaternion.Euler(0, 0, 0));
            Debug.Log("Spawned powerup" + _powerup + "at position" + waypointPos);
            
            _powerup.GetComponent<PowerUp>().waypointID = posRand;
            _powerup.GetComponent<PowerUp>().PowerUpSpawner = this;
            
            count += 1;

        }

        
  
    }

    int GetRandomPosition()
    {
        return Random.Range(0, waypoints.Length);
    }
    
    int GetRandomPowerup()
    {
        return Random.Range(0, powerUps.Length);
    }
}
