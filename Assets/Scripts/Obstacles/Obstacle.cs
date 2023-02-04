using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int waypointID;
    public ObstacleSpawner ObstacleSpawner;
    
    //This one gives a set of variables and methods for other PowerUps to use
    public void Clear()
    {
        ObstacleSpawner.waypoints[waypointID].hasObstacle = false;
        
    }

}