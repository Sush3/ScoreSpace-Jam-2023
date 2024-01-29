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
    
    private FMOD.Studio.EventInstance instanceReload;
    void Start()
    {
        ammo = maxAmmo;
        instanceReload = FMODUnity.RuntimeManager.CreateInstance("event:/Ship/SFX_Turret_Reload");
    }

    void Update()
    {
        instanceReload.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));

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
            FMODUnity.RuntimeManager.PlayOneShot("event:/Ship/SFX_Turret_Fire", transform.position);

            if (ammo==0)
            {
                reloadTimer = Time.time + reloadTime;
                instanceReload.start();
            }
        }
        if (ammo==0&&Time.time>=reloadTimer)
        {
            ammo = maxAmmo;
            ammoText.text = ammo.ToString();
        }
    }
    public void AddRateOfFire(float x)
    {
        rateOfFire += x;
    }
    public void AddReloadTime(float x)
    {
        reloadTime += x;
    }
}
