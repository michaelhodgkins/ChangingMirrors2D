using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField] GameObject firePrefab;
    [SerializeField] GameObject fireWallPrefab;
    [SerializeField] GameObject waterPrefab;
    public float fireRate = 1;
    private bool hasShot = false;
    public Camera cam;
    public Transform shoulder;
    public float armLength = 2f;
    public AudioSource shotAudio;
    public float damage = 50;
    void Update()
    {
        Vector3 shoulderToMousesDir = cam.ScreenToWorldPoint(Input.mousePosition) - shoulder.position;
        shoulderToMousesDir.z = 0;
       transform.position = shoulder.position + (armLength * shoulderToMousesDir.normalized);
        firePoint.up = shoulderToMousesDir;
        
        if (Input.GetMouseButtonDown(0) && hasShot == false || Input.GetMouseButton(1) && hasShot == false)
        {
            Shoot();
        }
    }

    IEnumerator ShootingMechanic()
    {
        if (hasShot && Input.GetMouseButton(0))
        {
            Instantiate(firePrefab, firePoint.position, firePoint.rotation);
            shotAudio.Play();
            yield return new WaitForSecondsRealtime(fireRate);
            Debug.Log("wait: " + fireRate);

            hasShot = false;
        }
        else if(hasShot && Input.GetMouseButton(1))
        {
            Instantiate(waterPrefab, firePoint.position, firePoint.rotation);
            shotAudio.Play();
            yield return new WaitForSecondsRealtime(8);
            Debug.Log("water");
            hasShot = false;

        }
        /*
         
        else if (hasShot && "Input to be decided"))
        {
            Instantiate(fireWallPrefab, firePoint.position, firePoint.rotation);
            shotAudio.Play();
            yield return new WaitForSecondsRealtime(fireRate);
            Debug.Log("wait: " + fireRate);

            hasShot = false;
        }
        Another projectile
        */

    }

    void Shoot()
    {
        hasShot = true;
        StartCoroutine(ShootingMechanic());
    }

}