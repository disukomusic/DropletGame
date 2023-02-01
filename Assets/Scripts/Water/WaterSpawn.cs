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

    void Start()
    {
        
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
        int rand = GetRandom();
        while (rand == _lastRand) 
        {
            rand = GetRandom();
        }
        _lastRand = rand;
            
        GameObject currentWaypoint = waypoints[rand];
        Vector3 waypointPos = currentWaypoint.transform.position;
        if (_droplet != null)
        {
            Destroy(_droplet);
        }
        _droplet = Instantiate(dropletPrefab, waypointPos, Quaternion.Euler(-90, 0, 0));
        //_droplet.transform.Rotate(-90, 0, 0, Space.Self);
    }

    int GetRandom()
    {
        return Random.Range(0, waypoints.Length);
    }
}