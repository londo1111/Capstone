using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private TextMeshProUGUI ammoDisplay;
    private AudioSource audioSrc;

    [SerializeField]
    private float bulletForce = 20f;

    private const float cooldown = 0.1f;

    private const int maxAmmo = 10;
    private int currentAmmo;

    private bool canShoot = true;
    private bool reloading = false;

    private const string defAmmo = "Ammo:\n10 / 10";

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();

        currentAmmo = maxAmmo;
        ammoDisplay = GameObject.Find("AmmoDisplay").GetComponent<TextMeshProUGUI>();
        ammoDisplay.text = defAmmo;
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(0) && canShoot && !EventSystem.current.IsPointerOverGameObject())
        {
            if (currentAmmo > 0)
            {
                StartCoroutine(Shoot());
            }
            else
            {
                StartCoroutine(Reload());
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo != maxAmmo && !reloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        currentAmmo--;
        audioSrc.Play();

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        
        yield return new WaitForSeconds(cooldown);

        ammoDisplay.text = "Ammo:\n" + currentAmmo.ToString() + " / 10";
        canShoot = true;
    }

    private IEnumerator Reload()
    {
        canShoot = false;
        reloading = true;

        currentAmmo = maxAmmo;
        ammoDisplay.text = "RELOADING...";

        yield return new WaitForSeconds(2f);

        ammoDisplay.text = defAmmo;
        canShoot = true;
        reloading = false;
    }
}