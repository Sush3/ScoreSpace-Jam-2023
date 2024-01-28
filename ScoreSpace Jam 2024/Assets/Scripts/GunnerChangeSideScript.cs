using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GunnerChangeSideScript : MonoBehaviour
{
    bool isLookingRight = true;
    //right and left
    [SerializeField]
    CinemachineVirtualCamera[] virtualGunnerCameras;
    [SerializeField]
    Behaviour[] rightSideComponents;
    [SerializeField]
    Behaviour[] leftSideComponents;
    GunnerMovementScript gms;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isLookingRight = !isLookingRight;
            ActivateSide(isLookingRight);
        }
    }
    void OnEnable()
    {
        gms = GetComponent<GunnerMovementScript>();
        ActivateSide(isLookingRight);
    }
    private void OnDisable()
    {
        foreach (var component in rightSideComponents)
        {
            component.enabled = false;
        }
        foreach (var component in leftSideComponents)
        {
            component.enabled = false;
        }
    }
    void ActivateSide(bool isRight)
    {
        if (isRight)
        {
            virtualGunnerCameras[0].Priority = 4;
            virtualGunnerCameras[1].Priority = 3;
            foreach (var component in rightSideComponents)
            {
                component.enabled = true;
            }
            foreach (var component in leftSideComponents)
            {
                component.enabled = false;
            }
        }
        else
        {
            virtualGunnerCameras[0].Priority = 3;
            virtualGunnerCameras[1].Priority = 4;
            foreach (var component in rightSideComponents)
            {
                component.enabled = false;
            }
            foreach (var component in leftSideComponents)
            {
                component.enabled = true;
            }
        }
        Debug.Log(gms);
        gms.SetIsLookingRight(isLookingRight);
    }
}
