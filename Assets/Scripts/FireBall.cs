using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed = 2f;
    public int damage;
    [SerializeField] Rigidbody2D rb;
   
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
        Destroy(gameObject, 2);
        rb.AddForce(Vector2.up * speed * Time.deltaTime, ForceMode2D.Impulse);
    }
}
