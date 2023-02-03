using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }
    public void ResetPlayerPosition()
    {
        _transform.position = new Vector3(0, 19.05f, -65.05f);

    }
}
