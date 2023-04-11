using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMine : MonoBehaviour
{
    public float speed = 20f;
    public int damage;
    public Rigidbody2D rb;
 
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    private void Update()
    {
        Destroy(gameObject,2);
    }
}
