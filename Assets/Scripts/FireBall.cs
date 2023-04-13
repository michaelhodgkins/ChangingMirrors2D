using TMPro;
using Unity.VisualScripting;
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

    private void FixedUpdate()
    {
        Destroy(gameObject, 2);
        rb.AddForce(transform.up * speed);
    }

}
