using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class WaterSpawn : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject dropletPrefab; 
    private int _lastRand = 0;
    private GameObject _droplet;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {   
            SpawnWater();
        }
    }
    public void SpawnWater()
    {
        //get a random index from the waypoints list
        int rand = GetRandom();
        //generate indexes until a new one is returned
        while (rand == _lastRand) 
        {
            rand = GetRandom();
        }
        //store the index of the current waypoint as the last selected one
        _lastRand = rand;
        
        //set the current waypoint to the random index and then set the position of it
        GameObject currentWaypoint = waypoints[rand];
        Vector3 waypointPos = currentWaypoint.transform.position;
        
        //if a droplet is already present in the scene, destroy it
        if (_droplet)
        {
            Destroy(_droplet);
        }
        //instantiate a droplet at the position of the waypoint (and rotate so its upright, stupid blender)
        _droplet = Instantiate(dropletPrefab, waypointPos, Quaternion.Euler(-90, 0, 0));
        _droplet.tag = "Droplet";
    }

    int GetRandom()
    {
        return Random.Range(0, waypoints.Length);
    }
}