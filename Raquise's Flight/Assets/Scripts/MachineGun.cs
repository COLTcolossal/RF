using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float fireRate = 0.2f;
    private float nextFire = 0f;
    public GameObject paused;
    public GameObject settings;
    public ParticleSystem muzzleFlash;

    void Update()
    {
        if (paused.activeInHierarchy == false)
        {
            if (settings.activeInHierarchy == false)
            {
                if (Input.GetButton("Fire1") && Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    Shoot();
                }
            }

        }
    }

    void Shoot()
    {
        //Shooting Logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        muzzleFlash.Play();
    }
}

