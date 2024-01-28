using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTurretScript : Turret
{
    [SerializeField]
    Transform firePoint;
    protected override void Fire()
    {
        SpawnRocket(firePoint);
    }
}
