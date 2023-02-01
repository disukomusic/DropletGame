using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAnimate : MonoBehaviour
{
    private Transform _transform;
    private void Start()
    {
        StartCoroutine(Hover());
        _transform = GetComponent<Transform>();
    }

    IEnumerator Hover()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1);
            _transform.position = new Vector3(_transform.position.x, _transform.position.y + 1, _transform.position.z);
            yield return new WaitForSeconds(1);
            _transform.position = new Vector3(_transform.position.x, _transform.position.y - 1, _transform.position.z);
        }
    }
}
