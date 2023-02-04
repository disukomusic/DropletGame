using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InfoText : MonoBehaviour
{
    public TMP_Text infoText;

    private void Awake()
    {
        infoText = GetComponent<TMP_Text>();
    }

    public void CollectDroplets()
    {
        infoText.text = "Collect Droplets!";

    }
    
    public void DepositDroplets()
    {
        infoText.text = "Carrying Droplet!";

    }
    
    public void NewPowerUp()
    {
        infoText.text = "New PowerUp Spawned!";

    }
}
