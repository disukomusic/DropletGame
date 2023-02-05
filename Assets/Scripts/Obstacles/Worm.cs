using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : Obstacle
{
    public float degreesPerSecond = 120f;
    private void Update()
    {
        transform.Rotate(new Vector3(Time.deltaTime * degreesPerSecond,0f , 0f), Space.Self);
    }

    private void Awake()
    {
        StartCoroutine(WormTimer());
    }

    IEnumerator WormTimer()
    {
        yield return new WaitForSeconds(15);
        ObstacleSpawner.count--;
        Clear();
        Destroy(gameObject);
    }
}
