using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static int count = 0;
    public GameManager gameManager;
    public ObstacleSpawn[] waypoints;
    public GameObject[] obstacles;
    public Player player;
    
    private int _lastPosRand = 0;
    private int _lastObstacleRand = 0;
    private GameObject _obstacle;

    public void SpawnObstacle()
    {
        //get a random index for the waypoints list, as well as a random index for the powerups list
        int posRand = GetRandomPosition();
        int obstacleRand = GetRandomObstacle();

        //generate indexes until a new one is returned
        while (posRand == _lastPosRand)
        {
            posRand = GetRandomPosition();
        }

        //store the index of the current waypoint as the last selected one
        _lastPosRand = posRand;
        _lastObstacleRand = obstacleRand;

        //set the current waypoint to the random index and then set the position of it
        ObstacleSpawn currentWaypoint = waypoints[posRand];
        Vector3 waypointPos = currentWaypoint.waypoint.position;

        //instantiate an obstacle at the position of the waypoint
        if (count < 2 && !currentWaypoint.hasObstacle)
        {
            currentWaypoint.hasObstacle = true;
            _obstacle = Instantiate(obstacles[obstacleRand], waypointPos, Quaternion.Euler(0, 0, 0));

            _obstacle.GetComponent<Obstacle>().waypointID = posRand;
            _obstacle.GetComponent<Obstacle>().ObstacleSpawner = this;
            
            count ++;
            Debug.Log("There are currently" + count + "obstacles");

        }
    }
    

    int GetRandomPosition()
    {
        return Random.Range(0, waypoints.Length);
    }
    
    int GetRandomObstacle()
    {
        return Random.Range(0, obstacles.Length);
    }
}
