using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitateScript : MonoBehaviour
{
    [SerializeField]
    float strength;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(-transform.position.normalized * strength / transform.position.sqrMagnitude);
    }
    public float GetStrength()
    {
        return strength;
    }
}
