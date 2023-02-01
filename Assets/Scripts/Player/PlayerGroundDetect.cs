using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetect : MonoBehaviour
{
    private PlayerMove _playerController;
    private void Awake()
    {
        _playerController = GetComponent<PlayerMove>();
    }
    void OnCollisionEnter(Collision collision) //detect when touching the ground and then set to true.
    {
        if(collision.gameObject.CompareTag("Ground")) 
        {
            _playerController.grounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))//detect when not touching the ground and then set to false.
        {
            _playerController.grounded = false;
        }
    }
}
