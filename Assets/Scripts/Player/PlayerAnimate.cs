using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    private Transform _transform;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _transform = GetComponent<Transform>();
        StartCoroutine(RunAnim());
    }   

    IEnumerator RunAnim()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            _transform.localScale = new Vector3(_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
            _audioSource.pitch = 1f;
            _audioSource.Play();
            yield return new WaitForSeconds(0.1f);
            _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
            _audioSource.pitch = 1.2f;
            _audioSource.Play();
        }

    }
}
