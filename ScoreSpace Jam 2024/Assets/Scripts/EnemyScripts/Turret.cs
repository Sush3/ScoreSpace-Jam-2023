using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : Enemy
{
    [SerializeField]
    GameObject rocketPrefab;
    [SerializeField]
    GameObject destroyedPrefab;
    [SerializeField]
    float fireRate;
    [SerializeField]
    float randomDelayMin;
    [SerializeField]
    float randomDelayMax;
    [SerializeField]
    float activateDistanceThreshold;
    float timer;
    void Start()
    {
        timer += Random.Range(randomDelayMin, randomDelayMax);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( timer < Time.time )
        {
            Fire();
            timer = Time.time + fireRate;
        }
    }
    protected abstract void Fire();

    protected void SpawnRocket(Transform firePoint)
    {
        Instantiate(rocketPrefab, firePoint.position, firePoint.rotation); 
    }
    protected override void DieEffect()
    {
        Instantiate(destroyedPrefab, transform.position, transform.rotation);
    }
}
