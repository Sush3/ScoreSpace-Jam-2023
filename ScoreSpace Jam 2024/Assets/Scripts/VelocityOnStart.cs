using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityOnStart : MonoBehaviour
{
    [SerializeField]
    Vector3 startVelocity;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = startVelocity;
    }
}
