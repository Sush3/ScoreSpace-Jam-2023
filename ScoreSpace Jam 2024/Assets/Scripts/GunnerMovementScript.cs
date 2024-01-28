using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerMovementScript : MonoBehaviour
{
    [SerializeField]
    float angularDragStrength;
    [SerializeField]
    float rollSpeed;
    Rigidbody rb;
    bool isLookingRight=true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Rotate(transform.forward, isLookingRight);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Rotate(transform.forward, !isLookingRight);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Rotate(transform.up, false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Rotate(transform.up, true);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Rotate(transform.right, isLookingRight);
        }
        if (Input.GetKey(KeyCode.E))
        {
            Rotate(transform.right, !isLookingRight);
        }

        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)&& !Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.E))
        {
            rb.angularDrag = angularDragStrength;
        }
        else
        {
            rb.angularDrag = 0.05f;
        }
    }

    public void SetIsLookingRight(bool x)
    {
        isLookingRight = x;
    }
    void Rotate(Vector3 v,bool isLookingRight)
    {
        rb.AddTorque(-v * rollSpeed * (isLookingRight ?-1:1));
    }
}
