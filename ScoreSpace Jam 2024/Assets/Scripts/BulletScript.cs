using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed;
    [SerializeField]
    float lifetime;
    Rigidbody rb;
    Vector3 velocity;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = Time.time + lifetime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = velocity;
        if (timer<Time.time)
        {
            Destroy(this);
        }
    }
    public void AddShipVelocity(Vector3 vel)
    {
        velocity = transform.forward * bulletSpeed + vel;
    }
}
