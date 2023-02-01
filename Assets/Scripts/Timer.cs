using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timer = 30.0f;
    public Text disvar;
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        double b = System.Math.Round(timer, 2);
        disvar.text = b.ToString();

        if (timer < 0)
        {
            Debug.Log("Completed");
        }
    }
}
