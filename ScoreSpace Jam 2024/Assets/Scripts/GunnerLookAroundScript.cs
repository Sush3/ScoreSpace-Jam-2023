using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GunnerLookAroundScript : MonoBehaviour
{
    bool isLookingRight = true;
    //right and left
    [SerializeField]
    CinemachineVirtualCamera[] virtualGunnerCameras;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (isLookingRight)
            {
                virtualGunnerCameras[0].Priority = 4;
                virtualGunnerCameras[1].Priority = 3;
            }
            else
            {
                virtualGunnerCameras[0].Priority = 3;
                virtualGunnerCameras[1].Priority = 4;
            }
            isLookingRight = !isLookingRight;
        }
    }
}
