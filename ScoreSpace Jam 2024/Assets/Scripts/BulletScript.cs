using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed;
    [SerializeField]
    float lifetime;
    [SerializeField]
    GameObject explosion;
    [SerializeField]
    float splashRadius;
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
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log(other.name);
            other.GetComponent<Enemy>().Hit(20);
            Die();
        }
        else if (other.CompareTag("Terrain"))
        {
            foreach (var collider in Physics.OverlapSphere(transform.position,splashRadius))
            {
                if (collider.CompareTag("Enemy"))
                {
                    other.GetComponent<Enemy>().Hit(20);
                }
            }
            Die();
        }
    }
    void Die()
    {
        
        Instantiate(explosion, transform.position-(rb.velocity*Time.deltaTime*2), transform.rotation);
        Destroy(gameObject);
    }
    public void AddShipVelocity(Vector3 vel)
    {
        velocity = transform.forward * bulletSpeed + vel;
    }
}
