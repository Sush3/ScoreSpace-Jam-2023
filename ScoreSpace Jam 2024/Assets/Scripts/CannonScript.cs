using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CannonScript : MonoBehaviour
{
    [SerializeField]
    Transform[] shootPoints;
    [SerializeField]
    float rateOfFire;
    [SerializeField]
    float reloadTime;
    [SerializeField]
    int maxAmmo;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    RecoilScript[] recoilScripts;
    [SerializeField]
    Rigidbody shipRigidbody;
    [SerializeField]
    TMP_Text ammoText;

    bool isLastBarrelUsedRight =false;

    float timer=0;
    float reloadTimer = 0;
    int ammo;
    void Start()
    {
        ammo = maxAmmo;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= timer&& ammo>0)
        {
            Transform shootPoint = shootPoints[isLastBarrelUsedRight ? 0 : 1];
            recoilScripts[isLastBarrelUsedRight ? 0 : 1].Shoot();
            BulletScript bs = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation*Quaternion.Euler(0,-90,0)).GetComponent<BulletScript>();
            bs.AddShipVelocity(shipRigidbody.velocity);
            timer = Time.time + rateOfFire;
            isLastBarrelUsedRight = !isLastBarrelUsedRight;
            ammo--;
            ammoText.text = ammo.ToString();
            if (ammo==0)
            {
                reloadTimer = Time.time + reloadTime;
            }
        }
        if (ammo==0&&Time.time>=reloadTimer)
        {
            ammo = maxAmmo;
            ammoText.text = ammo.ToString();
        }
    }
}
