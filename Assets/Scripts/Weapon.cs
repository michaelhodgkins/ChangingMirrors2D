using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    int fireRate = 1;
    
    public bool hasShot = false;

    public GameObject bulletPrefab;


    public Camera cam;
    public Transform shoulder;
    public float armLength = 2f;
    public AudioSource shotAudio;

    private void Start()
    {
        shoulder = transform.parent.transform;

    }
    void Update()
    {
       Vector3 shoulderToMousesDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shoulder.position;
        shoulderToMousesDir.z = 0;
        transform.position = shoulder.position + (armLength * shoulderToMousesDir.normalized);
        if (Input.GetMouseButtonDown(0) && hasShot == false)
        {
            Shoot();
           
        }
    }

    IEnumerator ShootingMechanic()
    {
        if (hasShot)
        {
            

            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            shotAudio.Play();
            yield return new WaitForSecondsRealtime(fireRate);
            Debug.Log("wait 1 second");

            hasShot = false;
        }

    }

    void Shoot()
    {
        hasShot = true;
        StartCoroutine(ShootingMechanic());
    }

}