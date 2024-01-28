using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHitScript : Enemy
{
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
            Debug.Log("AAAAA");
            Die();
        }
    }
    protected override void DieEffect()
    {
        //boom vfx
    }
}
