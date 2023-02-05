using System;
using UnityEngine;

public class WaterMagnet : MonoBehaviour
{

    private Transform _magnet; 
    private Floater _floater;

    void Awake()
    {
        _floater = GetComponent<Floater>();
        EnableFloater();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("droplet is colliding with" + other);
        if(other.CompareTag("MagnetPowerup"))
        {
            _magnet = other.transform;
            DisableFloater();
        }
    }

    void Update()
    {
        if (_magnet)
        {
            transform.position = Vector3.MoveTowards(transform.position, _magnet.position, 100f * Time.deltaTime);
        }
    }

    void DisableFloater()
    {
        if (_floater)
        {
            Debug.Log("Disabled Droplet Floater");
            _floater.enabled = false;
        }
    }
    
    void EnableFloater()
    {
        if (_floater)
        {
            Debug.Log("Enabled Droplet Floater");

            _floater.enabled = true;
        }
    }
}