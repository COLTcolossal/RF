using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public Transform firePoint;
    public Rigidbody2D bulletPrefab;
    private float fireRate = 0.5f;
    private float nextFire = 0f;
    public float bulletSpeed = 2500f;
    public GameObject paused;
    public GameObject settings;
    public ParticleSystem muzzleFlash;

    void FixedUpdate()
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
       for (int i = 0; i <= 2; i++)
        {

            var spawnedBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            switch (i)
            {
                case 0:
                    spawnedBullet.AddForce(firePoint.up * bulletSpeed + new Vector3(0f, 90f, 0f));
                    break;

                case 1:
                    spawnedBullet.AddForce(firePoint.up * bulletSpeed + new Vector3(0f, 0f, 0f));
                    break;

                case 2:
                    spawnedBullet.AddForce(firePoint.up * bulletSpeed + new Vector3(0f, -90f, 0f));
                    break;

            }

        }

        muzzleFlash.Play();

    }
}
