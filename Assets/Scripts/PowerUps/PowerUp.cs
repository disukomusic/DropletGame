using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int waypointID;
    public PowerUpSpawner PowerUpSpawner;
    
    //This one gives a set of variables and methods for other PowerUps to use
    public void Clear()
    {
        PowerUpSpawner.waypoints[waypointID].hasPowerup = false;
        
    }

}
