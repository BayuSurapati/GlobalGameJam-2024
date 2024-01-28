using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float nextFire = 0f;

    private void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
