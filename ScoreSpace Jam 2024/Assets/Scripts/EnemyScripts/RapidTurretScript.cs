using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidTurretScript : Turret
{
    [SerializeField]
    Transform[] firePoints;
    int nextBarrel;
    protected override void Fire()
    {
        SpawnRocket(firePoints[nextBarrel]);
        nextBarrel++;
        nextBarrel %= firePoints.Length;
    }
}
