using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTurretScript : Turret
{
    [SerializeField]
    Transform[] firePoints;
    protected override void Fire()
    {
        foreach (var firePoint in firePoints)
        {
            SpawnRocket(firePoint);
        }
    }
}
