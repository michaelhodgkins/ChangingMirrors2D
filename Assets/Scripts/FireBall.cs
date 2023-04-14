using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class FireBall : MonoBehaviour
{
    public float speed = 2f;
    [SerializeField] Rigidbody2D rb;
    Weapon weapon;
    Enemy enemy;

    void Start()
    {
    

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("enemy"))
        {
            enemy = collision.GetComponent<Enemy>();
            weapon = FindObjectOfType<Weapon>();
            enemy.TakeDamage(weapon.damage);
            Debug.Log(weapon.damage);
            
        }
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        Destroy(gameObject, 2);
        rb.AddForce(transform.up * speed);
    }

}
