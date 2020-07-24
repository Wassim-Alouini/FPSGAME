using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Camera fpsCam;
    [SerializeField] float range = 100f;
    public ParticleSystem muzzleFlash;
    public float fireRate = 20;
    float nextTimeToFire = 0f;
    void Awake()
    {
        fpsCam = Camera.main;
    }
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if(Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
            
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            HealthManager hm = hit.transform.GetComponent<HealthManager>();
            // If we hit an object with a HealthManager
            if (hm)
            {
                // Deal damage
                hm.TakeDamage(34);
            }
        }
    }
}
