using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    int fireRate = 1;
    
    public bool hasShot = false;

    public GameObject bulletPrefab;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && hasShot == false)
        {
            Shoot();
            Debug.Log("input");
        }
    }

    IEnumerator ShootingMechanic()
    {
        if (hasShot)
        {
            Debug.Log("Shooting mechanic fired off");

            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            yield return new WaitForSecondsRealtime(fireRate);
            Debug.Log("wait 1 second");

            hasShot = false;
        }

    }

    void Shoot()
    {
        hasShot = true;
        Debug.Log("has shot == true");

        StartCoroutine(ShootingMechanic());
    }

}