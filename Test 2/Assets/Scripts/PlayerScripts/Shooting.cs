using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
   

    public float bulletForce = 20f;
    private bool canShoot = true;
    private int currentAmmo = 10;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            Shoot();
            currentAmmo--;

            if (currentAmmo <= 0)
            {
                StartCoroutine(ShootDelay());
            }
        }
    }

    void Shoot()
    {


        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(1);
        currentAmmo = 10;
        canShoot = true;
    }

}