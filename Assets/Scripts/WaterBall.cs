using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class WaterBall : MonoBehaviour
{
    public float speed = 2f;
    [SerializeField] Rigidbody2D rb;
    Enemy enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            enemy = collision.GetComponent<Enemy>();
            enemy.speed = 0;
            Debug.Log("hit");
        }
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        Destroy(gameObject, 2);
        rb.AddForce(transform.up * speed);
    }


}

