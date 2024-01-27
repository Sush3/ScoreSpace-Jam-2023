using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModesManager : MonoBehaviour
{
    [SerializeField]
    Behaviour[] captainViewComponents;
    [SerializeField]
    Behaviour[] gunnerViewComponents;
    bool isCaptain = true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isCaptain = true;
            Cursor.lockState = CursorLockMode.Locked;
            foreach (var component in gunnerViewComponents)
            {
                component.enabled = false;
            }
            foreach (var component in captainViewComponents)
            {
                component.enabled = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Cursor.lockState = CursorLockMode.Confined;
            isCaptain = false;
            foreach (var component in gunnerViewComponents)
            {
                component.enabled=true;
            }
            foreach (var component in captainViewComponents)
            {
                component.enabled = false;
            }
        }
    }
}
