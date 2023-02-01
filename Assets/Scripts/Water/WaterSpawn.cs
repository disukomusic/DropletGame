using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class WaterSpawn : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject dropletPrefab;
    private GameObject _previousWaypoint;
    private int _lastRand = 0;
    void Start()
    {
        _previousWaypoint = waypoints[1];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {   
            SpawnWater();
        }
    }
    public void SpawnWater()
    {
        int rand = GetRandom(); //This is just that line I sent a sec ago in a method
        while (rand == _lastRand) {
            rand = GetRandom();
        }
        _lastRand = rand;
            
        GameObject currentWaypoint = waypoints[rand];
        Vector3 waypointPos = currentWaypoint.transform.position;
        GameObject waterDrop = Instantiate(dropletPrefab, waypointPos, Quaternion.identity);
        
        // GameObject currentWaypoint = waypoints[Random.Range(0, waypoints.Length)];
        // Vector3 waypointPos = currentWaypoint.transform.position;
        // if (_previousWaypoint != currentWaypoint)
        // {
        //     GameObject waterDrop = Instantiate(dropletPrefab, waypointPos, Quaternion.identity);
        // }
        // else
        // {
        //     currentWaypoint = waypoints[Random.Range(0, waypoints.Length)];
        // }
        // _previousWaypoint = currentWaypoint;

    }

    int GetRandom()
    {
        return Random.Range(0, waypoints.Length);
    }
}
