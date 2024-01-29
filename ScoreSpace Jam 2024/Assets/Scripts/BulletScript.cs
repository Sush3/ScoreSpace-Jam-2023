using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    float bulletDamage;
    [SerializeField]
    float bulletSpeed;

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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = velocity;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().Hit(bulletDamage);
            Die();
        }
        else if (other.CompareTag("Terrain"))
        {
            foreach (var collider in Physics.OverlapSphere(transform.position,splashRadius))
            {
                if (collider.CompareTag("Enemy"))
                {                    
                    collider.GetComponent<Enemy>().Hit(bulletDamage);
                }
            }
            Die();
        }
    }
    private void OnDestroy()
    {
        Instantiate(explosion, transform.position-(rb.velocity*Time.deltaTime*2), transform.rotation);
    }
    void Die()
    {      
        Destroy(gameObject);
    }
    public void AddShipVelocity(Vector3 vel)
    {
        velocity = transform.forward * bulletSpeed + vel;
    }
}
