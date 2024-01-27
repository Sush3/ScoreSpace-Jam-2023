using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LookAtAsteroidScript : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera lookAtAsteroidCamera;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lookAtAsteroidCamera.Priority = 2;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            lookAtAsteroidCamera.Priority = 0;
        }
    }
}
