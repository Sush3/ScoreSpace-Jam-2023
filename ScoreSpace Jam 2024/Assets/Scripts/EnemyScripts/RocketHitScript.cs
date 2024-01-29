using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHitScript : Enemy
{
    [SerializeField]
    GameObject explosionVFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealthScript>().Hit();
            Die();
        }
        else if (other.CompareTag("Terrain"))
        {
            points = 0;
            Die();
        }
    }
    protected override void DieEffect()
    {
        Instantiate(explosionVFX, transform.position, transform.rotation);
    }
}
