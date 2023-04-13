using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    public float fireRate = 1;
    private bool hasShot = false;
    public Camera cam;
    public Transform shoulder;
    public float armLength = 2f;
    public AudioSource shotAudio;
    void Update()
    {
        Vector3 shoulderToMousesDir = cam.ScreenToWorldPoint(Input.mousePosition) - shoulder.position;
        shoulderToMousesDir.z = 0;
       transform.position = shoulder.position + (armLength * shoulderToMousesDir.normalized);
        firePoint.up = shoulderToMousesDir;
        
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