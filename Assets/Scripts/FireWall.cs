using UnityEngine;


public class FireWall : MonoBehaviour
{
    public float speed = 8f;
    [SerializeField] Rigidbody2D rb;
    Weapon weapon;
    Enemy enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            enemy = collision.GetComponent<Enemy>();
            weapon = FindObjectOfType<Weapon>();
            enemy.TakeDamage(weapon.damage / 2);
            Debug.Log(weapon.damage);

        }
    }

    private void FixedUpdate()
    {
        Destroy(gameObject, 3);
        rb.AddForce(transform.up * speed);
    }

}
