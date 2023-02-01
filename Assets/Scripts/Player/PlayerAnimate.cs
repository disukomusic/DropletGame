using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
        StartCoroutine(RunAnim());
    }   

    IEnumerator RunAnim()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            _transform.localScale = new Vector3(_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
            yield return new WaitForSeconds(0.1f);
            _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
        }

    }
}
