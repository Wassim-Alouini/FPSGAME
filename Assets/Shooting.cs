using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float ammo = 30;
    public float fireRate = 1f;
    public float reloadSpeed = 0f;
    public GameObject bulletPrefab;
    public  Transform firePoint;
    public GameObject Player;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            InvokeRepeating("Shoot", 0, fireRate);
        }
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("Shoot");
        }
        if(ammo <= 0)
        {
            CancelInvoke("Shoot");
            StartCoroutine(Reload());
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.transform.forward = firePoint.forward;
        ammo = ammo - 1;
    }
    IEnumerator Reload()
    {
        Debug.Log("Reloading");
        yield return new WaitForSeconds(reloadSpeed);
        ammo = 30;
    }


}
